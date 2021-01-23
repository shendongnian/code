    List<HistoricalStock> retval = new List<HistoricalStock>();
    
                    try
                    {
                        File.WriteAllText("G:/Test.csv", web.DownloadString(string.Format("http://ichart.finance.yahoo.com/table.csv?s={0}&c={1}", ticker, yearToStartFrom)));
                    }
                    catch (FileNotFoundException exc)
                    {
                        Console.WriteLine(exc.Message);
                    }
    
                    StreamReader sr = new StreamReader("G:/Test.csv");
    
                    string currentLine;
                    List<string> stoksList = new List<string>();
    
                    // while stockList isn't empty
                    while ((currentLine = sr.ReadLine()) != null)
                        stoksList.Add(currentLine);
    
                    // First row is a header 
                    stoksList.RemoveAt(0);
    
                    foreach (string str in stoksList)
                    {
                        string[] parsedString = str.Split(',');
    
                        HistoricalStock hs = new HistoricalStock();
    
                        hs.Date = Convert.ToDateTime(parsedString[0]);
                        hs.Open = Convert.ToDouble(parsedString[1]);
                        hs.High = Convert.ToDouble(parsedString[2]);
                        hs.Low = Convert.ToDouble(parsedString[3]);
                        hs.Close = Convert.ToDouble(parsedString[4]);
                        hs.Volume = Convert.ToDouble(parsedString[5]);
                        hs.AdjClose = Convert.ToDouble(parsedString[6]);
    
                        retval.Add(hs);
                    }
