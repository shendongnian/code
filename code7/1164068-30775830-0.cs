    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication33
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement m_AllCells = doc.Descendants().Where(x => x.Name.LocalName == "AllCells").FirstOrDefault();
                AllCells allCells = new AllCells(m_AllCells); 
            }
        }
        public class AllCells
        {
            public int size {get;set;}
            public int version {get;set;}
            public Items items { get; set; }
            public AllCells(XElement m_AllCells)
            {
                size = int.Parse(m_AllCells.Elements().Where(x => x.Name.LocalName == "_size").FirstOrDefault().Value);
                version = int.Parse(m_AllCells.Elements().Where(x => x.Name.LocalName == "_version").FirstOrDefault().Value);
                XElement childItem = m_AllCells.Elements().Where(x => x.Name.LocalName == "_items").FirstOrDefault();
                if (childItem != null)
                {
                    items = new Items(childItem);
                }
            }
        }
        public class Items
        {
            public int? iD { get; set; }
            public int? size { get; set; }
            public List<Cell> cells {get; set;}
            public Items(XElement items)
            {
                XAttribute newId = items.Attributes().Where(x => x.Name.LocalName == "Id").FirstOrDefault();
                if (newId == null)
                {
                    iD = null;
                }
                else
                {
                    iD = int.Parse(newId.Value);
                }
                XAttribute newSize = items.Attributes().Where(x => x.Name.LocalName == "Size").FirstOrDefault();
                if (newSize == null)
                {
                    size = null;
                }
                else
                {
                    size = int.Parse(newSize.Value);
                }
                List<XElement> childCells = items.Elements().Where(x => x.Name.LocalName == "Cell").ToList();
                if (childCells == null)
                {
                    cells = null;
                }
                else
                {
                    cells = new List<Cell>();
                    foreach (XElement childCell in childCells)
                    {
                        cells.Add(new Cell(childCell)); 
                    }
                }
            }
        }
        public class Cell
        {
            public bool nil { get; set; }
            public int? m_ref {get;set;}
            public int? iD {get; set;}
            public Neighbor neighbor { get; set; }
            public string state { get; set; }
            public Cell(XElement cell)
            {
                XAttribute newNil = cell.Attributes().Where(x => x.Name.LocalName == "nil").FirstOrDefault();
                if (newNil == null)
                {
                    nil = false;
                }
                else
                {
                    nil = (cell.Value == "true")? true : false;
                }
                XAttribute newRef = cell.Attributes().Where(x => x.Name.LocalName == "Ref").FirstOrDefault();
                if (newRef == null)
                {
                    m_ref = null;
                }
                else
                {
                    m_ref  = int.Parse(newRef.Value);
                }
                XAttribute newId = cell.Attributes().Where(x => x.Name.LocalName == "Id").FirstOrDefault();
                if (newId == null)
                {
                    iD = null;
                }
                else
                {
                    iD = int.Parse(newId.Value);
                }
                XElement newState = cell.Elements().Where(x => x.Name.LocalName == "State").FirstOrDefault();
                if (newState == null)
                {
                    state = string.Empty;
                }
                else
                {
                    state = newState.Value;
                }
                XElement newNeighbors = cell.Elements().Where(x => x.Name.LocalName == "Neighbors").FirstOrDefault();
                if (newNeighbors == null)
                {
                    neighbor = null;
                }
                else
                {
                    neighbor = new Neighbor(newNeighbors);
                }
            }
        }
        public class Neighbor
        {
            public int? iD { get; set; }
            public int? size { get; set; }
            public int? version { get; set; }
            public Items items { get; set; }
            public Neighbor(XElement neighbor)
            {
                XAttribute newId = neighbor.Attributes().Where(x => x.Name.LocalName == "Id").FirstOrDefault();
                if (newId == null)
                {
                    iD = null;
                }
                else
                {
                    iD = int.Parse(newId.Value);
                }
                XAttribute newSize = neighbor.Attributes().Where(x => x.Name.LocalName == "Size").FirstOrDefault();
                if (newSize == null)
                {
                    size = null;
                }
                else
                {
                    size = int.Parse(newSize.Value);
                }
                version = int.Parse(neighbor.Elements().Where(x => x.Name.LocalName == "_version").FirstOrDefault().Value);
                XElement childItem = neighbor.Elements().Where(x => x.Name.LocalName == "_items").FirstOrDefault();
                if (childItem != null)
                {
                    items = new Items(childItem);
                }
            }
        }
    }
