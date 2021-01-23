    public class User
    {
      public long UserId { get; set; }
      public string Name { get; set; }
      private string _stringArrayCore = string.Empty;
      // Warnning: do not use this in Bussines Model
      public string StringArrayCore
      {
        get
        {
          return _stringArrayCore;
        }
        set
        {
          _stringArrayCore = value;
        }
      }
      [NotMapped]
      public ICollection<string> StringArray
      {
        get
        {
          var splitString = _stringArrayCore.Split(';');
          var stringArray = new Collection<string>();
          foreach (var s in splitString)
          {
            stringArray.Add(s);
          }
          return stringArray;
        }
        set
        {
          _stringArrayCore = string.Join(";", value);
        }
      }
    }
