     var book = new BookModel//fill it with your data
            {
                Author = "a",
                Language = "l",
                Name = "n",
                PagesCount = 0,
                Pulbisher = "p",
                Series = "s",
                Year = 1990
            };
            var list=new List<BookModel>();
            list.Add(book);
            var bookContainer = new HashSet<BookModel>(list);//you have to pass list to HashSet constructor
            dataGridViewBookList.DataSource = bookContainer.ToList();
