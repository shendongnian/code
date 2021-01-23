    private ImageSource image
    {
       get
       {
          if (Gender == Gender.Male)
          {
             return ImageSource.FromFile("Male.png")
          }
          else if (Gender == Gender.Female)
          {
             return ImageSource.FromFile("Female.png")
          }
       }
    }
