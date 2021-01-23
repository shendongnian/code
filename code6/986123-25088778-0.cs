    public void button_Click(object sender, EventArgs e)
            {
                this.panelBoarder.Controls.Clear() //Hide old content
    
                if (this.pageTwo == null)
                    this.pageTwo = new PageTwo(); // Create Page Two
    
                this.panelBoarder.Controls.Add(this.pageTwo);
                this.pageTwo.Visible = true;
            }
