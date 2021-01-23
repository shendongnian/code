    // This method read the file and populate a List of Playlist.
    // Each PlayList contain a list of MP3 songs
    public List<Playlist> GetPlayLists()
    {
        // read all lines from the text file
        string[] lines = File.ReadAllLines(@"c:\Temp\playlists.txt");
        // declare a playlists variable to hold all the playlists and their songs
        var playlists = new List<Playlist>();
        // Loop through all the playlists (each line in the text file represents a playlist)
        for (int plIdx = 0; plIdx <= lines.Length; plIdx++)
        {
            // split in order to fins all the MP3 songs
            string[] res = lines[plIdx].Split(';');
            // create a new playlist (its name is passed into the constructor)
            var playlist = new Playlist(res[0]);
            // loop the songs (starting from index 1 since index=0 is the playlist name)
            for (int songIdx = 1; songIdx <= res.Length; songIdx++)
            {
                // Add to the playlist each song
                playlist.Add(new MP3(res[songIdx]));
            }
            playlists.Add(playlist);
        }
        return playlists;
    }
    // Play list class containing all the MP3 songs (each line in text file)
    class Playlist
    {
        public readonly List<MP3> SongList { get; private set; }
        public string Name { get; private set; }
        public Playlist(string name)
        {
            Name = name;
            SongList = new List<MP3>();
        }
        public void Add(MP3 mp3)
        {
            SongList.Add(mp3);
        }
    }
    // MP3 Song class
    class MP3
    {
        public string Location { get; private set; }
        public MP3(string location)
        {
            Location = location;
        }
    }
