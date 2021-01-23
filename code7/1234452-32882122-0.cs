    public void ListGenres()
    {
      System.Xml.Linq.XElement xLibrary = System.Xml.Linq.XElement.Load(@"c:\Library.xml");
      System.Xml.Linq.XElement xSongs = xLibrary.Element("Songs");
      System.Collections.Generic.IEnumerable<List<string>> genresList = 
                    from code in xSongs.Elements("Song")
                    let genreList = (string)code.Element("Genres")
                    select genreList.ToList();
      foreach (List<string> genreList in genresList)
      {
         var orderedList = genreList.OrderBy(x=>x);
         foreach(string genre in orderedList)
          Console.WriteLine(genre);
      }
    }
