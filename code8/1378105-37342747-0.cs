    public MainWindow()
        {
            InitializeComponent();
            if (tbxSum.Text == "")
            {
                btnDiv.IsEnabled = false;
                btnMult.IsEnabled = false;
            }
        }
        protected void btnSumClick(object sender, EventArgs e)
        {
            btnDiv.IsEnabled = true;
            btnMult.IsEnabled = true;
            var myButton = (Button)sender;
            int pos = tbxSum.Text.Length;
           
            if (pos > 0)
            {
                if ((tbxSum.Text[pos - 1] == '/' || tbxSum.Text[pos - 1] == '*') &&
                    (myButton.Content.ToString() == "/" || myButton.Content.ToString() == "*"))
                {
                    int location = tbxSum.Text.Length - 1;
                    tbxSum.Text = tbxSum.Text.Remove(location, 1);
                }
            }
        }
