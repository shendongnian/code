                string [][] Ws1Data = new string[3][];
                Ws1Data[0] = new string[3] { "2015", "2016", "2016" };
                Ws1Data[1] = new string[3] { "5asda", "6asda","7asa" };
                Ws1Data[2] = new string[3] { "5sdfdf", "6asda","6dsfsdf" };
                var filter = Ws1Data.Select((row,i) => row.Where((x,j)  => Ws1Data[0][j] == ("2016")).ToArray()).ToArray();
    
                int nRows = Ws1Data[0].Length;
                int nColumns = Ws1Data.Length;
                string tempString = " ";
                for (int i = 0; i < nRows; i++)
                {
                    tempString = " ";
                    for (int j = 0; j < nColumns; j++)
                    {
                        tempString = tempString + Ws1Data[j][i];
                        tempString = tempString + "    ";
                    }
                    Console.WriteLine(tempString);
                }
                Console.WriteLine("Filtered by 2016");
                nRows = filter[0].Length;
                nColumns = filter.Length;
                for (int i = 0; i < nRows; i++)
                {
                    tempString = " ";
                    for (int j = 0; j < nColumns; j++)
                    {
                        tempString = tempString + filter[j][i];
                        tempString = tempString + "    ";
                    }
                    Console.WriteLine(tempString);
                }
    
                Console.ReadLine();
