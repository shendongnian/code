    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string uploadFilename = "dog.jpg";
                XDocument xdoc = XDocument.Load(@"C:\Users\admin\XMLFile1.xml");
                
                //// check if the xml file is having node mathcing upload filename name 
                List<XElement> xel = xdoc.Descendants("Name").Where(x => x.Value == uploadFilename).ToList();
    
                if (xel.Any())
                {
                    Console.WriteLine("I match the currently open file's name: " + uploadFilename);
    
                    //// Get list of element list's Ancestors
                    //// will return
                    ////<Name>dog.jpg</Name>
                    ////<PatternDistancesList>
                    ////  <PatternDistance>278</PatternDistance>
                    ////  <PatternDistance>380</PatternDistance>
                    ////</PatternDistancesList>
    
                    //// looop through it
                    foreach (XElement item in xel.Ancestors().Elements().ToList())
                    {
    
                    }
    
                    //// OR get another list
                    List<XElement> foundItems = xel.Ancestors().Elements().ToList();
                }
    
            }
        }
    }
