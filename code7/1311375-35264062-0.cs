    private void CreateNotes(string note)
    {
    //txt : Rich Text Box dynamically created for each note
    //test : Selected text in 'note'
    int index = txt.Text.ToUpper().IndexOf(test.ToUpper());
    txt.Select(index, test.Length);
    txt.SelectionFont = new Font(txt.Font.Name, txt.Font.Size, txt.Font.Style^ FontStyle.Bold);
     Random rnd = new Random();
    
    //x global variable initialised as 1
    if(x % 2 == 1)
    txt.SelectionBackColor = Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255));
    x++;  }
     
