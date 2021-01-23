    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.txt";
            enum Section
            {
                NONE,
                TRANSACTION,
                USER
            }
            static void Main(string[] args)
            {
                Section section = Section.NONE;
                string TransactionNo = ""; 
                StreamReader file = new StreamReader(FILENAME);
                string line = "";
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length > 0 && !line.StartsWith("---------------"))
                    {
                        //Transaction details
                        switch (section)
                        {
                            case Section.NONE:
                                if(line.StartsWith("TRANSACTION NUMBER"))
                                {
                                    section = Section.TRANSACTION;
                                }
                                break;
                            case Section.TRANSACTION:
                                if (!line.Contains("User Actions and Comments:"))
                                {
                                    TransactionNo = line.Substring(0, 22).Trim();
                                    Console.WriteLine("TrnNo : {0}", TransactionNo);
                                }
                                else
                                {
                                    section = Section.USER;
                                }
                                break;
                            case Section.USER:
                                break;
                        }
                    }
                }//end of while
                file.Close();
           }
        }
    }
     
    ​
