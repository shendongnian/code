    MyForm : Form
    {
       private readonly Tooltip _toolTip = new ToolTip();
       public MyForm()
       { 
           InitialiseComponent();
           _textBox.TextChanged += (sender, args) => UpdateTips();
          UpdateTips();
       }
       private void UpdateTips()
       {
          string tip =  string.IsNullOrEmpty(_textBox.Text) 
                 ? "You should supply some text here" 
                 : null;
         _toolTip.SetToolTip(_textBox, tip);
       }
    }
