       public void UpdateBooks(int id, List<Book> updatedBooks)
        {
            var author = GetAuthorById(id);
            var existingBooks = author.Books.ToList();
            UpdateRelatedEntityCollection<Book>(existingBooks, updatedBooks);
            UnitOfWork.Context.SaveChanges();
        }
