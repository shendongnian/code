    public class FileData {
      public bool IsParsed {get; private set; }
      public String FileName {get; private set; }
      public DateTime Date {get; private set; }
      public String Ref {get; private set; }
      public FileData(String path) {
        FileName = path;
        if (String.IsNullOrEmpty(path))
          return;
        int p = path.IndexOf('_');
        if (p < 0)
          return;
        Ref = path.Substring(0, p);
        DateTime dt;
        IsParsed = DateTime.TryParseExact(path.Substring(p + 1), 
          "yyyy-MM-dd", 
          CultureInfo.InvariantCulture, 
          DateTimeStyles.None, 
         out dt);
        Date = dt;
      }
    }
