     var listFromDb= db.XTable.Where(x => x.Id > 5).ToList();
     var list = new List<Package>();
     foreach (var item in listFromDb)
     {
         var a = new Package()
         {
              AccountNo = item.AccountNo,
              CreateDate = item.CreateDate,
              IsResultCreated = item.IsResultCreated,
            };
            list.Add(a);
          }
