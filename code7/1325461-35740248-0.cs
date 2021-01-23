    using(StreamWriter vWriteFile = new StreamWriter("Positions2.csv"))
    {
            var path = @"C:\Users\jhochbau\documents\visual studio 2015\Projects\CsvReader\CSVReader3\Position_2016_02_25.0415.csv";
    
            if (vShowBoth == false)
            {
                //This determines whether to view by account or by underlying.
                Console.WriteLine("Please enter 0 if you wish to see sums by account, or 12 if you wish to see by underlying");
                int vViewControl = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Account" + "  Settle Sum" + " Open Sum" + " Buy Sum" + " Sell Sum");
                using (var parsedLines = File.ReadLines(path).Select(line => line.Split(',')).GetEnumerator())
                {
                    bool vMore = parsedLines.MoveNext();
                    while (vMore)
                    {
                        // Initialize
                        bool vWasSuccessful;
                        var vAccount = parsedLines.Current[vViewControl];
                        double vSettleMMSum = 0;
                        double vOpenSum = 0;
                        int vBuySum = 0;
                        int vSellSum = 0;
    
                        do
                        {
                            double vParseSettleMM = 0;
                            double vParseOpen = 0;
                            int vParseBuy = 0;
                            int vParseSell = 0;
    
                            //Parsing data read in from strings, into temp variables
                            vWasSuccessful = double.TryParse(parsedLines.Current[7], out vParseSettleMM);
                            vWasSuccessful = double.TryParse(parsedLines.Current[8], out vParseOpen);
                            vWasSuccessful = int.TryParse(parsedLines.Current[6], out vParseBuy);
                            vWasSuccessful = int.TryParse(parsedLines.Current[10], out vParseSell);
    
                            //adding temp variabels to sum
                            vSettleMMSum += vParseSettleMM;
                            vOpenSum += vParseOpen;
                            vBuySum += vParseBuy;
                            vSellSum += vParseSell;
    
                            vMore = parsedLines.MoveNext();
                        }
                        //sets up when to break
                        while (vMore && vAccount == parsedLines.Current[vViewControl]);
    
                        //After each Break need to print out Account name and sums from above.
                        // Do printing here as part of the loop, at the very end of the loop code block.
                        Console.WriteLine("--------------------------------------------------------");
    
                        Console.WriteLine(vAccount + "  " + vSettleMMSum + "  " + vOpenSum + "   " + vBuySum + " " +
                            vSellSum);
    
                        //vWriteFile.Write(vAccount + "," + vSettleMMSum + "," + vOpenSum + "," + vBuySum + "," +
                        //   vSellSum);
    
                        vWriteFile.WriteLine("{0},{1},{2},{3},{4}", vAccount, vSettleMMSum, vOpenSum, vBuySum, vSellSum);
    
                        //reset sums for next loop
                        vSettleMMSum = 0;
                        vOpenSum = 0;
                        vBuySum = 0;
                        vSellSum = 0;
    
                    }
                }
            }
    }
