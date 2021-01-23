    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualBasic.FileIO;
    namespace CsvToListExp
    {
    class Program
    {
        public static void Main(string[] args)
        {
            // HARD_CODED FOR EXAMPLE ONLY - TO BE RETRIEVED FROM APP.CONFIG IN REAL PROGRAM
            string hospPath = @"C:\\events\\inbound\\OBLEN_COB_Active_Inv_Advi_Daily_.csv";
            string vendPath = @"C:\\events\\outbound\\Advi_OBlen_Active_Inv_Ack_Daily_.csv";
            List<DenialRecord> hospList = new List<DenialRecord>();
            List<DenialRecord> vendList = new List<DenialRecord>();
            //List<DenialRecord> hospExcpt = new List<DenialRecord>();  // Created at point of use for now
            //List<DenialRecord> vendExcpt = new List<DenialRecord>();  // Created at point of use for now
            using (TextFieldParser hospParser = new Microsoft.VisualBasic.FileIO.TextFieldParser(hospPath))
            {
                hospParser.TextFieldType = FieldType.Delimited;
                hospParser.SetDelimiters(",");
                hospParser.HasFieldsEnclosedInQuotes = false;
                hospParser.TrimWhiteSpace = true;
                while (!hospParser.EndOfData)
                {
                    try
                    {
                        string[] row = hospParser.ReadFields();
                        if (row.Length <= 7)
                        {
                            DenialRecord dr = new DenialRecord(row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
                            hospList.Add(dr);
                        }
                    }
                    catch (Exception e)
                    {
                        // do something
                        Console.WriteLine("Error is:  {0}", e.ToString());
                    }
                }
                hospParser.Close();
                hospParser.Dispose();
            }
            using (TextFieldParser vendParser = new Microsoft.VisualBasic.FileIO.TextFieldParser(vendPath))
            {
                vendParser.TextFieldType = FieldType.Delimited;
                vendParser.SetDelimiters(",");
                vendParser.HasFieldsEnclosedInQuotes = false;
                vendParser.TrimWhiteSpace = true;
                while (!vendParser.EndOfData)
                {
                    try
                    {
                        string[] row = vendParser.ReadFields();
                        if (row.Length <= 7)
                        {
                            DenialRecord dr = new DenialRecord(row[0], row[1], row[2], row[3], row[4], row[5], row[6]);
                            vendList.Add(dr);
                        }
                    }
                    catch (Exception e)
                    {
                        // do something
                        Console.WriteLine("Error is:  {0}", e.ToString());
                    }
                }
                vendParser.Close();
                vendParser.Dispose();
            }
            // Compare the lists each way for denials not in the other source
            List<DenialRecord> hospExcpt = hospList.Except(vendList).ToList();
            List<DenialRecord> vendExcpt = vendList.Except(hospList).ToList();
        }
    }
    }
