     List<GetAllNewsForUser> lll = new List<GetAllNewsForUser>();
     foreach (var item in usersLi)
     {
         NewsInfo nnn = new NewsInfo();
         nnn.NewsTitle = item.NewsTitle;
         nnn.NewsId = item.NewsId;
         if (!lll.Any(x=> x.UserName == item.UserName)
         { 
  
              GetAllNewsForUser g = new GetAllNewsForUser();
              g.UserName = item.UserName;
              g.NewsInfos.Add(nnn);
              lll.Add(g);
         }
         else
         {
              lll.Where(x=>x.UserName == item.Username).FirstOrDefault().NewsInfos.Add(nnn)
              
         }        
         
     }
