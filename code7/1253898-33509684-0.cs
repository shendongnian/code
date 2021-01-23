    private void button3_Click(object sender, EventArgs e)
        {
            String match = textbox.Text;
            foreach (Object b in list)
            {
                Books book = (Books)b;
                if (book.Author.Contains(match) || book.Title.Contains(match) || book.Genre.Contains(match))
                {
                    Form2 form = new Form2();
                   form.Book = book;
                    form.Show();
                }
            }
        }
