    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    namespace TestElements
    {
        public class Elements
        {
            public static string[] ROW_SEPARATOR = { " " };
            public static string[] ELEMENT_SEPARATOR = { "|" };
            private int _nextRowId;
            public List<string> ColumnHeaders;
            public Dictionary<int, Dictionary<string, string>> Rows;
            public Elements()
            {
                this._nextRowId = 0;
                this.ColumnHeaders = new List<string>();
                this.Rows = new Dictionary<int, Dictionary<string, string>>();
            }
            public void AddFromFile(string path)
            {
                // Read all the file, and split in lines
                string[] lines = File.ReadAllText(path).Split(ROW_SEPARATOR, StringSplitOptions.None);
                // Get the headers
                List<string> headers = lines[0].Split(ELEMENT_SEPARATOR, StringSplitOptions.None).ToList();
            
                // Add headers that are new
                foreach (string header in headers)
                {
                    if (!this.ColumnHeaders.Contains(header))
                    {
                        this.ColumnHeaders.Add(header);
                    }
                }
                // Parse every line
                for (int i = 1; i < lines.Length; i++)
                {
                    // Split a line into elements
                    List<string> elements = lines[i].Split(ELEMENT_SEPARATOR, StringSplitOptions.None).ToList();
                    // Build a row of elements
                    Dictionary<string, string> row = new Dictionary<string,string>();
                    for (int j = 0; j < headers.Count; j++)
                    {
                        row.Add(headers[j], elements[j]);
                    }
                    // Add the row to our store
                    this.AddRow(row);
                }
            }
            private void AddRow(Dictionary<string, string> rowdata)
            {
                this.Rows.Add(this._nextRowId, rowdata);
                this._nextRowId++;
            }
        }
    }
