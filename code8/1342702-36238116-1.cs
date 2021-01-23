    public List<AlbumsByArtistVM> AlbumsByArtist()
    {
        var temp = (from ar in db.Artists
                    join al in db.Albums on ar.ArtistID equals al.ArtistID
                    select new AlbumsByArtistVM
                    { 
                       AlbumName =al.AlbumName, 
                       ArtistName =ar.Name, 
                       ArtistLLastName  =ar.LastName 
                    });
        return temp;
    }
        
