    string[] lines = File.ReadAllLines("playlists.txt"); // 100 lines 
    for (int y = 0; y < lines.Length; y++) loops through array index 0 to 99
    {
         string[] res = lines[y].Split(';'); // lines[y] should be something like c:\song.mp3 ; c:\song.mp3 ; c:\song.mp3
         // res[0] = Library
         // res[1] = C:\Users\Blah\Desktop\Iphone Music\Queens of the Stone Age - If I Had A Tail.mp3
         currentPlaylist = new Playlist(res[0].Trim());
         currentPlaylist.Add(new MP3(res[1].Trim()));
    }
