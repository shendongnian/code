    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.Script.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            private static DataTable dt;
            private static Dictionary<string, int> columnRowManager;
    
            static void Main(string[] args)
            {
                //var json = "[{'firstName':'John', 'lastName':'Doe'},{'firstName':'Anna', 'lastName':'Smith'},{'firstName':'Peter','lastName': 'Jones'} ]";
                //var json = "{ 'glossary': { 'title': 'example glossary','GlossDiv': { 'title': 'S','GlossList': { 'GlossEntry': { 'ID': 'SGML','SortAs': 'SGML','GlossTerm': 'Standard Generalized Markup Language','Acronym': 'SGML','Abbrev': 'ISO 8879:1986','GlossDef': { 'para': 'A meta-markup language, used to create markup languages such as DocBook.','GlossSeeAlso': ['GML', 'XML'] },'GlossSee': 'markup' } } } } }";
                var json = "{ 'A': 'A0' , 'B' : { 'B2' : 'B2 - Val', 'B3' : [{'B30' : 'B30 - Val1' ,'B31' : 'B31 - Val1'}]}, 'C': ['C0', 'C1']}";
                var jss = new JavaScriptSerializer();
                dt = new DataTable();
                columnRowManager = new Dictionary<string, int>();
    
                try
                {
                    // Deal with an object root
                    var dict = jss.Deserialize<Dictionary<string, object>>(json);
                    GetColumnsAndRowsFromJsonDictionary(dict);
                }
                catch (InvalidOperationException ioX)
                {
                    // Deal with an Array Root
                    var dictionaries = jss.Deserialize<Dictionary<string, object>[]>(json);
                    foreach (var dict in dictionaries)
                    {
                        GetColumnsAndRowsFromJsonDictionary(dict);
                    }
                }
    
                DumpTableToConsole();
            }
    
            private static void DumpTableToConsole()
            {
                WriteColumnsToConsole();
                WriteRowsToConsole();
                Console.ReadKey();
            }
    
            private static void WriteRowsToConsole()
            {
    
                // Write out the Rows
                foreach (DataRow row in dt.Rows)
                {
                    foreach (DataColumn col in dt.Columns)
                    {
                        Console.Write(row[col.ColumnName].ToString().PadRight(12) + ",");
                    }
                    Console.WriteLine();
                }
            }
    
            private static void WriteColumnsToConsole()
            {
                foreach (DataColumn col in dt.Columns)
                {
                    Console.Write(col.ColumnName.PadRight(12) + ",");
                }
                Console.WriteLine();
                Console.WriteLine("-------------------------------------------------------------------------------");
            }
    
            private static void AddDataToTable(string column, string cellValue)
            {
                AddColumnIfNew(column);
                int targetRowPosition = DetermineTargetRow(column);
                AddRowIfRequired(targetRowPosition);
                dt.Rows[targetRowPosition - 1][column] = cellValue;
            }
    
            private static void AddRowIfRequired(int targetRowPosition)
            {
                if (dt.Rows.Count < targetRowPosition)
                {
                    dt.Rows.Add();
                }
            }
    
            private static int DetermineTargetRow(string column)
            {
                int targetRowPosition;
                columnRowManager.TryGetValue(column, out targetRowPosition);
                targetRowPosition++;
                columnRowManager[column] = targetRowPosition;
                return targetRowPosition;
            }
    
            private static void AddColumnIfNew(string column)
            {
                if (!dt.Columns.Contains(column))
                {
                    dt.Columns.Add(new DataColumn(column, typeof(String)));
                    columnRowManager.Add(column, 0);
                }
            }
    
            private static void GetColumnsAndRowsFromJsonDictionary(Dictionary<string, object> dictionary)
            {
                // Catch the curse of recursion - null is your friend (enemy!) 
                if (dictionary == null) return;
    
                foreach (var kvp in dictionary)
                {
                    if (kvp.Value.GetType() == typeof(Dictionary<string, object>))
                    {
                        // Process an embedded dictionary (hierarchy)
                        var subDictionary = kvp.Value as Dictionary<string, object>;
                        GetColumnsAndRowsFromJsonDictionary(subDictionary);
                    }
                    else if (kvp.Value.GetType() == typeof(System.Collections.ArrayList))
                    {
                        ProcessArrayList(kvp);
                    }
                    else if (kvp.Value.GetType() == typeof(String))
                    {
                        AddDataToTable(kvp.Key, kvp.Value.ToString());
                    }
                    else
                    {
                        throw new NotSupportedException(string.Format("Err2: Type '{0}' not supported", kvp.Value.GetType().ToString()));
                    }
                }
            }
    
            private static void ProcessArrayList(KeyValuePair<string, object> kvp)
            {
                // Process each independant item in the array list 
                foreach (var arrItem in kvp.Value as System.Collections.ArrayList)
                {
                    if (arrItem.GetType() == typeof(String))
                    {
                        AddDataToTable(kvp.Key, arrItem.ToString());
                    }
                    else if (arrItem.GetType() == typeof(Dictionary<string, object>))
                    {
                        var subArrDictionary = arrItem as Dictionary<string, object>;
                        GetColumnsAndRowsFromJsonDictionary(subArrDictionary);
                    }
                    else
                    {
                        throw new NotSupportedException(string.Format("Err1: Type '{0}' not supported", arrItem.GetType().ToString()));
                    }
                }
            }
        }
    }
