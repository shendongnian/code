    public MyForm()  // ctor
    {
       foreach(Control c in this.Controls) 
          if(c is PictureBox) c.Click += (s, e) () => 
          {
             PictureBoxClick((s as PictureBox).Name);
          }
    }
    private void PictureBoxClick(string name)
    {
        if(name.Contains("13")) // do something with picturebox 13        
    }
