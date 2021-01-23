      User user = new User { ID = 12135 };
      Book book = new Book { ID = 1};
      user.Books.Add(book);  
      context.Users.Add(user);
      context.SaveChanges();
