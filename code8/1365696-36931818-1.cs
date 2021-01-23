    public static string PathCombineNoEx(string path1, string path2)
     {
      if (String.IsNullOrWhiteSpace(path1))
      {
        throw new ArgumentnullException(path1);
      }
     //Same goes for Path2
     
     return System.IO.Path.Combine(path1, path2);
    }
