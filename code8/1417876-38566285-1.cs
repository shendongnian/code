    namespace SqlBulkCopy
    {
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Diagnostics;
        using System.Data;
        using System.Data.SqlClient;
    
        public class CsvReader : IDataReader
        {
            private readonly char CSV_DELIMITER = ',';
    
            private readonly StreamReader _sr;
            private readonly Dictionary<string, Func<string, object>> _csv2SqlType;
            private readonly string[] _headers;
    
            private string _line;
            private string[] _values;
    
            public int FieldCount { get { return _headers.Length; } }
    
            public CsvReader(string filePath, Dictionary<string, Func<string, object>> csvColumn2SqlTypeDict)
            {
                if (string.IsNullOrEmpty(filePath))
                    throw new ArgumentException("is null or empty", "filePath");
                if (!System.IO.File.Exists(filePath))
                    throw new IOException(string.Format("{0} doesn't exist or access denied", filePath));
                if (csvColumn2SqlTypeDict == null)
                    throw new ArgumentNullException("csvColumn2SqlTypeDict");
    
                _sr = new StreamReader(filePath);
                _csv2SqlType = csvColumn2SqlTypeDict;
                _headers = ReadHeaders();
                ValidateHeaders();
            }
            public object GetValue(int i)
            {
                // Get column value
                var colValue = _values[i];
                // Get column name
                var colName = _headers[i];
                // Try to convert to SQL type
                try { return _csv2SqlType[colName](colValue); }
                catch { return null; }
            }
            public bool Read()
            {
                if (_sr.EndOfStream) return false;
    
                _line = _sr.ReadLine();
                _values = _line.Split(CSV_DELIMITER);
                // If row is invalid, go to next row
                if (_values.Length != _headers.Length)
                    return Read();
                return true;
            }
            public void Dispose()
            {
                _sr.Dispose();
            }
            private void ValidateHeaders()
            {
                if (_headers.Length != _csv2SqlType.Keys.Count)
                    throw new InvalidOperationException(string.Format("Read {0} columns, but csv2SqlTypeDict contains {1} columns", _headers.Length, _csv2SqlType.Keys));
                foreach (var column in _headers)
                {
                    if (!_csv2SqlType.ContainsKey(column))
                        throw new InvalidOperationException(string.Format("There is no convertor for column '{0}'", column));
                }
            }
            private string[] ReadHeaders()
            {
                var headerLine = _sr.ReadLine();
                if (string.IsNullOrEmpty(headerLine))
                    throw new InvalidDataException("There is no header in CSV!");
                var headers = headerLine.Split(CSV_DELIMITER);
                if (headers.Length == 0)
                    throw new InvalidDataException("There is no header in CSV after Split!");
                return headers;
            }
        }
        public class Program
        {        
            public static void Main(string[] args)
            {
                // Converter from CSV columns to SQL columns
                var csvColumn2SqlTypeDict = new Dictionary<string, Func<string, object>>
                {
                    { "int", (s) => Convert.ToInt32(s) },
                    { "str", (s) => s },
                    { "double", (s) => Convert.ToDouble(s) },
                    { "date", (s) => Convert.ToDateTime(s) },
                };
                Stopwatch sw = Stopwatch.StartNew();
                try
                {
                    // example.csv
                    /***
                       int,str,double,date
                       1,abcd,2.5,15.04.2002
                       2,dab,2.7,15.04.2007
                       3,daqqb,4.7,14.04.2007
                     ***/
                    using (var csvReader = new CsvReader("example.csv", csvColumn2SqlTypeDict))
                    {
                        // TODO!!! Modify to your Connection string
                        var cs = @"Server=localhost\SQLEXPRESS;initial catalog=TestDb;Integrated Security=true";
                        using (var loader = new SqlBulkCopy(cs, SqlBulkCopyOptions.Default))
                        {
                            // TODO Modify to your Destination table
                            loader.DestinationTableName = "Test";
                            // Write from csvReader to database
                            loader.WriteToServer(csvReader);
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Got an exception: {0}", ex);
                    Console.WriteLine("Press 'Enter' to quit");
                    Console.ReadLine();
                    return;
                }
                finally { sw.Stop(); }
                Console.WriteLine("Data has been written in {0}", sw.Elapsed);
                Console.WriteLine("Press 'Enter' to quit");
                Console.ReadLine();
            }
            private static void ShowCsv(IDataReader dr)
            {
                int i = 0;
                while (dr.Read())
                {
                    Console.WriteLine("Row# {0}", i);
                    for (int j = 0; j < dr.FieldCount; j++)
                    {
                        Console.WriteLine("{0} => {1}", j, dr.GetValue(j));
                    }
                    i++;
                }
            }
        }
    }
