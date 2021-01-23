    using (MagickImage image = new MagickImage())
    {
      MagickReadSettings settings = new MagickReadSettings()
      {
        BackgroundColor = MagickColors.LightBlue, // -background lightblue
        FillColor = MagickColors.Black, // -fill black
        Font = "Arial", // -font Arial 
        Width = 530, // -size 530x
        Height = 175 // -size x175
      };
    
      image.Read("caption:This is a test.", settings); // caption:"This is a test."
      image.Write("caption_long_en.png"); // caption_long_en.png
    }
