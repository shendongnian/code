        var Albums = await App.DataModel.GetAlbum();
        if (Albums != null)
        {
            Frame.Navigate(typeof(ViewModel.AlbumView));
        }
        else
        {
        Frame.Navigate(typeof(ViewModel.AddAlbumView));
        }
 
