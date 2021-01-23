    using CsvHelper;
    using System.Collections.Generic;
    using System.IO;
    namespace Test
    {
        class Program
        {
            class CsvColumns
            {
                private string column_01;
                [CsvHelper.Configuration.Attributes.Name("Column 01")] // changes header/column name Column_01 to Column 01
                public string Column_01 { get => column_01; set => column_01 = value; }
            }
            static void Main(string[] args)
            {
                List<CsvColumns> csvOutput = new List<CsvColumns>();
                CsvColumns rows = new CsvColumns();
                rows.Column_01 = "data1";
                csvOutput.Add(rows);
                string filename = "test.csv";
                using (StreamWriter writer = File.CreateText(filename))
                {
                    CsvWriter csv = new CsvWriter(writer);
                    csv.WriteRecords(csvOutput);
                }
            }
        }
    }
