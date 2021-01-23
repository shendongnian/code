    int TotalPanelCount = 3;  //last index of panel will be 2
    int _index = 0;
    public int Index
    {
      get { return _index; }
      set { 
        if (TotalPanelCount < 3)
            _index = value;
        else
            _index = TotalPanelCount - 1; 
        ChangeIndex();
        }
    }
    
    private void btnNext_Click(object sender, EventArgs e)
    {
       Index++;
    }
    private void btnPrevious_Click(object sender, EventArgs e)
    {
       Index--;
    }
    private void btnClose_Click(object sender, EventArgs e)
    {
       this.Close();
    }
    
    private void ChangeIndex()
    {
        string _panelName = "penal" + Index.ToString();
    
        //Hide all visible panel
        var panels = (From Control cnt in this.Controls
                      Where cnt.getType().Name.Equals("Panel") &&
                      cnt.Name != _panelName && cnt.Visible == true
                      Select cnt).ToArray();
        foreach(Control cnt in panels)    
           cnt.Visible = false;
    
        //Displaying current panel
        Panel pnl = (Panel)this.Controls[_panelName];
        pnl.BringToFront();
        pnl.Visible = true;
    }
