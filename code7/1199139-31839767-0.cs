    private List<Button> closeButtons = new List<Button>()
    private void SetTabButtons()
    {
      // first remove all existing buttons
      for (int i=0;i<closeButtons.Count;i++) closeButtons[i].Parent=null ;
      closeButtons.Clear() ; 
      // create the close buttons
      for (int i=0;i<theTabControl.TabPages.Count;i++) 
      {
        // add some spaces to tab text for the close button
        theTabControl.TabPages[i].Text = theTabControl.TabPages[i].Text+"     "  ;
        Rectangle rect=theTabControl.GetTabRect(i);
              NewControl.Location = new System.Drawing.Point(X, Y);
        Button b = new Button() ;
        button.Text = "x" ;
        button.AutoSize = true;
        button.Location = new Point(rect.Right-button.Width-3,rect.top+3) ; 
        button.Parent   = theTabControl ;
        button.tag      = i ;
        button.Click   +=CloseTab_ButtonClick ;
        closeButtons.Add(button) ;
      }
      private void CloseTab_ButtonClick(object sender, EventArgs e) 
      { 
        int theTabPageIndex = (int)((Button)sender).Tag) ;
        // remove the tabpage here 
        ...
        // reset the buttons
        setTabButtons() ;
      }
