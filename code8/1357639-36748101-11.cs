    foreach (DictionaryEntry entry in reader)
    {
       if (entry.Key.ToString().Equals(name.ToLower()))
       {
            bamlStream = entry.Value as Stream;
            BitmapImage bmp = LoadImage(bamlStream);
            img.Source = bmp;
       }
    }
    public static BitmapImage LoadImage(Stream stream) 
    { 
       BitmapImage bmi; 
       using (MemoryStream ms1 = new MemoryStream()) 
       { 
          stream.CopyTo(ms1); 
          bmi = new BitmapImage(); 
          bmi.BeginInit(); 
          bmi.StreamSource = new MemoryStream(ms1.ToArray()); 
          bmi.EndInit(); 
       } 
       return bmi; 
    }
