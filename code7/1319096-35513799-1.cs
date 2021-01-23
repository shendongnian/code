    public string FlagPic
    {
      get
      {
        using (System.IO.MemoryStream m = new System.IO.MemoryStream())
        {
          ClassLibrary1.Resource1.flag.Save(m, ClassLibrary1.Resource1.flag.RawFormat);
          byte[] imageBytes = m.ToArray();    
          base64Image = System.Convert.ToBase64String(imageBytes);
          return String.Format("data:{1};base64,{0}", base64Image, ClassLibrary1.Resource1.flag.RawFormat);
        }
      }
    }
