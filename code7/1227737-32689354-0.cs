               lstfile = (from s in context.T_SelectionListDetails
                          .Where(c => idList.Select(n => n.ID)
                          .Contains(c.ID))
                          join p in context.T_UserAlbumDetails on   
                          s.UserAlbumDetails_ID  equals p.ID
              
                          select new AlbumPhotos
                          {
                            virtualPath = p.VirtualPath,
                            ID = s.ID
                          }).ToList();
  
