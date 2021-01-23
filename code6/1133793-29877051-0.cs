    return Query().Include("User")
                  .Select(x => new PostDto()
                   {
                       DatePosted = x.DatePosted,
                       StatusText = x.StatusText,
                       TypeOfPost = x.TypeOfPost,
                       User = new UserDto
                              {
                                  //Your propertoes here
                                  //eg Id = x.User.Id etc
                               }  
                   );
 
