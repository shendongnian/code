    namespace RegExptester
    {
        class Program
        {
    
            private static List<int> GetQuantity(string txtFile)
            {
                string tempLineValue;
                Regex regex = new Regex(@"[0-9]*:[a-zA-Z]*:\$[0-9]*\.[0-9]*:([0-9]*).*", RegexOptions.Compiled);
                List<int> retValue = new List<int>();
                using (StreamReader inputReader = new StreamReader(txtFile))
                {
                    while (null != (tempLineValue = inputReader.ReadLine()))
                    {
                        Match match = regex.Match(tempLineValue);
                        if (match.Success)
                        {
                           if(match.Groups.Count == 2)
                           {
                               int numberValue;
                               if (int.TryParse(match.Groups[1].Value, out numberValue))
                                   retValue.Add(numberValue);
                           }
                        }
                    }
                }
                return retValue;
            } 
    
            static void Main(string[] args)
            {
                var tmp = GetQuantity("c:\\tmp\\junk.txt");
            }
        }
    }
