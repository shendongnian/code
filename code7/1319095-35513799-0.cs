    public string FlagPic
    {
      get
      {
        using (System.IO.MemoryStream m = new System.IO.MemoryStream())
        {
          ClassLibrary1.Resource1.flag.Save(m, ClassLibrary1.Resource1.flag.RawFormat);
    
          return String.Format("data:{1};base64,{0}", m.ToArray(), ClassLibrary1.Resource1.flag.RawFormat);
        }
      }
    }
