    foreach(var item in idList)
    {
        var lstfile1 = (from s in context.T_SelectionListDetails
                   join p in context.T_UserAlbumDetails on s.UserAlbumDetails_ID equals p.ID
                   where s.ID == item.ID
                   select new AlbumPhotos
                           {
                               virtualPath = p.VirtualPath,
                               ID = s.ID
                           }).ToList();
          lstfile.AddRange(lstfile1);
    } 
