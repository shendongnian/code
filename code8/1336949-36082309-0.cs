        public void Add()
        {         
            List<Book> bookList = new List<Book>();
    
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                bookList.Add(new Book()
                {
                    Id = (string)dataGridView.Rows[i].Cells["Id"].Value,
                    Name = (string)dataGridView.Rows[i].Cells["Name"].Value,
                    Author = (string)dataGridView.Rows[i].Cells["Author"].Value,
                    NumberOfBooks = (string)dataGridView.Rows[i].Cells["NumberOfBooks "].Value,
                    Available = (string)dataGridView.Rows[i].Cells["Available"].Value
                });
            }
    
           //You can do anything now
        }
