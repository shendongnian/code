            static void Main(string[] args){ 
         try {
                    // I expect the Exception to be thrown here, but it's not
                    foreach (var str in GetStrings())
                    {
                        Console.WriteLine(str);
                    }
                }
            
                catch (Exception ex) {
            //Do whatever
            }
    }
                private static IEnumerable<string> GetStrings()
                {
                    // REPEATEDLY throws this exception
                    throw new Exception();
                    yield break;
                }
