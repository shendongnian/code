    public static int GetMatchingIndex(string searchKey)
     {
         string[] MyValues = new string[] { "windows", "dual sim", "32 gb", "Intel i5" };
         for (int i = 0; i < MyValues.Count(); i++)
         {
              if (searchKey.IndexOf(MyValues[i], StringComparison.InvariantCultureIgnoreCase) >= 0)
                 return i;
         }
         return -1;
     }
