    using ( var context = new YourContext)
       {
         var users = context.UserDbSet;
         var userEdications = context.UserEdication.DbSet ;
         var joinedTables =  from user in users
                             join userEdication in userEdications on user.userId  = userEdication.userId 
                             select new OutPutEntity
                             {
                                   Name = user.Name,
                                   Edication = userEdication.Edication
                             }
                             gridView.DataSource = joinedTables.toList(); // should be placed outside the using. (here just as a sample)
       }
