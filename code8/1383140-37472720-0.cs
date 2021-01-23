    public void Edit(Song song, string audioName, string artistName, IEnumerable<Category> categories)
    {
        song.AudioName = audioName;
        song.ArtistName = artistName;
        
        song.Categories.Clear();
        song.Categories = categories.ToList();
        
        _repository.Edit(song);
    }
