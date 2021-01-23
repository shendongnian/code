    namespace WindowsFormsApplication5
    {
        public class Program
        {
            public class Canciones
            {
                public string Album { get; set; }
                public string AlbumArtist { get; set; }
                public string AlbumCover { get; set; }
                public string Artist { get; set; }
                public string ArtistCover { get; set; }
                public string Genre { get; set; }
                public string GenreCover { get; set; }
                public string Path { get; set; }
                public string Title { get; set; }
                public int OID { get; set; }
            }
           public static void Main()
            {
    	   		int counter = 0;
                Siaqodb siaqodb = new Siaqodb(@"d:\Siaqodb\database\TEST\");
    
               List<Canciones> musicList = (from m in XDocument.Load(@"C:\Users\ivan_000\Desktop\MusicList.xml")
                                               .Descendants("Music")
                                               select new Canciones{
                                               Album = m.Element("Album").Value,
                                               AlbumArtist = m.Element("AlbumArtist").Value,
                                               AlbumCover = m.Element("AlbumCover").Value,
                                               Artist = m.Element("Artist").Value,
                                               ArtistCover = m.Element("ArtistCover").Value,
                                               Genre = m.Element("Genre").Value,
                                               GenreCover = m.Element("GenreCover").Value,
                                               Path = m.Element("Path").Value,
                                               Title = m.Element("Title").Value,
                                               OID = musicList.Count()                                          
    
                                               }).ToList();
    										   
    						foreach(Cancion cancion in musicList)
    						{
    							counter++;
    							if (counter <= 100)
    									siaqodb.StoreObject(cancion);	
    							else
    								break;					
    						}
    
            }
          
        }
