    class Program
        {
            private static void Main()
            {
                var data = "";
                const string data1 = "Data1";//First Data
                const string data2 = "Data2";//Second Data
                const int line1 = 1;//First Data Line
                const int line2 = 3;//Second Data Line
                var maxNoOfLines = Math.Max(line1, line2);
                for (var i = 1; i <= maxNoOfLines; i++)
                {
                    if (i == line1)
                    {
                        data += data1 + Environment.NewLine;
                    }
                    else if (i == line2)
                    {
                        data += data2 + Environment.NewLine;
                    }
                    else
                    {
                        data += Environment.NewLine;
                    }
                }
                File.WriteAllText(@"C:\NOBACKUP\test.txt", data);
            }
        }
