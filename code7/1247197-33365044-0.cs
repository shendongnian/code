    private void eventoaelementos()
     {
     foreach(ToolStripMenuItem t in this.menuStrip1.Items)
      {
        t.MouseEnter += new EventHandler(metodoMouseEnter);
        t.MouseLeave += new EventHandler(metodoMouseLeave);
        foreach(ToolStripItem t2 in t.DropDownItems)
        {
          if(t2 is ToolStripMenuItem)
          {
             //To discard the ToolStripSeparator's case in which I 
            //obtain an exception
              t2.MouseEnter += new EventHandler(metodoMouseEnter);
              t2.MouseLeave += new EventHandler(metodoMouseLeave);
           }
         }
       }
    }
    private void metodoMouseLeave(object sender, EventArgs e)
        {
          this.toolStripStatusLabel1.Text = "";
        }
        private void metodoMouseEnter(object sender, EventArgs e)
        {
          ToolStripItem t = sender as ToolStripItem;
          if(t!=null)
            {
                this.toolStripStatusLabel1.Text = t.Text;
            }
        }
