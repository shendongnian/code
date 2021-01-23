    private void button3_Click(object sender, EventArgs e)
    {
    String match = textbox.Text;
    List<Books> mybookslist = new List<Books>();
    foreach (Books b in list)
    {
        if (book.Author.Contains(match) || book.Title.Contains(match) || book.Genre.Contains(match))
            
        {
            mybookslist.Add(b);
        }
    }
    //Navigation code here with your data(mybookslist)
    }
