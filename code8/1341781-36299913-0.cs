     void Insert(Product product, int intUserId)
      {
         _unitofWork.Db.Entry(product).Collection(i => i.Users).Load();
          UserRepository userRepo = new UserRepository(_unitofWork);
            
         product.Users.Add(userRepo.GetAll().FirstOrDefault(U => U.UserID == intUserId));
            
      }
