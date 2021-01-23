    Program table = new Program();
                int[,] zumValues = table.ZumbaValues;
                string[] zumForm = new string[6] { "Mon", "Tues", "Wed", "Thurs", "Fri", "Sat" };
                for (int z = 0; z < zumForm.Length; z++)
                {
                    var Nums = "";
                    for (var t = 0; t < 4; t++)
                        Nums = Nums + table.zumba[z, t].ToString() + " ";
    
                    Console.Write("{0} {1}", zumForm[z],Nums);
                    Console.WriteLine();
                }
    
                Console.ReadLine();
