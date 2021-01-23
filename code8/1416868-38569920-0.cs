    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualBasic.FileIO;
    using ExportToExcel;
    
    namespace InputSide
    {
        internal class CsvLoader
        {
            private int columnCount = 7;    // backing store
            private string filePath;
            private List<DenialRecord> inputList = new List<DenialRecord>();
    
            public List<DenialRecord> InputList
            {
                set
                {
                    this.inputList = InputList;
                }
                get
                {
                    return inputList;
                }
            }
    
            // Default constructor
            internal CsvLoader()
            {
            }
    
            // Exposed constructor
            public CsvLoader(List<DenialRecord> InputList,  string FilePath, int ColumnCount)
            {
                this.inputList = InputList;
                this.filePath = FilePath;
            }
    
            // Load csv to List<T>
            public List<DenialRecord> CsvList(int columnCount)
            {
                using (TextFieldParser csvParser = new TextFieldParser(filePath))
                {
                    csvParser.TextFieldType = FieldType.Delimited;
                    csvParser.SetDelimiters(",");
                    csvParser.HasFieldsEnclosedInQuotes = false;
                    csvParser.TrimWhiteSpace = true;
    
                    while (!csvParser.EndOfData)
                    {
    
                        try
                        {
                            string[] row = csvParser.ReadFields();
                            if (row.Length <= 7)
                            {
                                DenialRecord dr = new DenialRecord(row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
                                inputList.Add(dr);
                            }
                        }
                        catch (Exception e)
                        {
                            // do something
                            Console.WriteLine("Error is:  {0}", e.ToString());
                        }
                    }
                    csvParser.Close();
                    csvParser.Dispose();
                }
                return inputList;
            }
        }
    }
