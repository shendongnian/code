      public static List<List<string>> GenerateListOfListOfStrings(string[,] result)
        {
            string[,] res = result;
            List<List<string>> listObj = new List<List<string>>();
            var list = new List<string>();
            foreach (var s in result)
            {
               list.Add(s);
            }
            listObj.Add(list);
            return listObj;
        }
