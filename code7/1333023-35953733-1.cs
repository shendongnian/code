     public static class ExtensionMethods
        {
            public static List<OfSomething> RepeatUntil(this List<OfSomething> list, Func<List<OfSomething>, bool> Until, Action<Exception> Error)
            {
                try {
                var ok = Until(list);
                while (!ok){
                    list = GetNewData();
                    ok = Until(list);
                }
                }
                catch (Exception iox) {
                    Error(iox);
                }
                return list;
    
            }
    
            private static List<OfSomething> GetNewData()
            {
                //Add new data or get new data or change something
                return RefreshData();
            }
    
            private static List<OfSomething> RefreshData()
            {
                //get  data from DB here etc.
                
            }
        }
