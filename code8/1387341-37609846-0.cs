    var UserInfoData = searchUserInfo.AsQueryable().FirstOrDefault;
    
      string  AspNetId = UserInfoData.AspNetId;                 
    
     var SerachAspNetUser = AspNetUserCollection.AsQueryable().SingleOrDefault(u=>u._id==AspNetId);
    var InsertAspNetUsercollection = destinationDatabase.GetCollection<ApplicationUser>("AspNetUsers");
                            InsertAspNetUsercollection.ReplaceOne(Builders<yourModel>.Eq(u=>u._id,AspNetId),UserInfoData ,new UpdateOptions {IsUpsert = true} );
  
