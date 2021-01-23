    using System;
    using System.Data;
    using RDotNet;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DataTable dtb = new DataTable();
                dtb.Columns.Add("Column1", Type.GetType("System.String"));
                dtb.Columns.Add("Column2", Type.GetType("System.String"));
                DataRow dtr1 = dtb.NewRow();
                dtr1[0] = "abc";
                dtr1[1] = "cdf";
                dtb.Rows.Add(dtr1);
                DataRow dtr2 = dtb.NewRow();
                dtr2[0] = "asdasd";
                dtr2[1] = "cdasdasf";
                dtb.Rows.Add(dtr2);
    
                using (var engine = REngine.GetInstance())
                {
                    string[,] stringData = new string[dtb.Rows.Count, dtb.Columns.Count];
                    for (int row = 0; row < dtb.Rows.Count; row++)
                    {
                        for (int col = 0; col < dtb.Columns.Count; col++)
                        {
                            stringData[row, col] = dtb.Rows[row].ItemArray[col].ToString();
                        }
                    }
                    CharacterMatrix matrix = engine.CreateCharacterMatrix(stringData);
                    engine.SetSymbol("myRDataFrame", matrix);
                    engine.Evaluate("myRDataFrame <- as.data.frame(myRDataFrame, stringsAsFactors = FALSE)");
                    engine.Evaluate("str(myRDataFrame)");
                    
                }
                Console.ReadKey();
            }
        }
    }
