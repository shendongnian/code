    MyForm : Form
    {
       private readonly Tooltip _toolTip = new ToolTip();
       public MyForm()
       { 
           InitialiseComponent();
           UpdateTips();
       }
       private void tbName_TextChanged(object sender, EventArgs args)
       { 
          UpdateTips();
       }
       private void UpdateTips()
       {
          string tip =  string.IsNullOrEmpty(tbName.Text) 
                 ? "You should supply some text here" 
                 : null;
         _toolTip.SetToolTip(tbName, tip);
       }
    }
