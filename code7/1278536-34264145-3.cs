    public Form1()
    {
        InitializeComponent();
        setCursor(Controls);
    }
    void setCursor(IEnumerable theControls)
    {
         foreach (Control control in theControls)
         {
             if (control.HasChildren)
             {
                  setCursor(control.Controls);
             }
             else
                 control.Cursor = Cursors.Hand;
         }
    }
