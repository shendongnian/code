    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                txtValue1.KeyDown += TxtValue1_KeyDown;
            }
    
            private void TxtValue1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    string csvLine = Clipboard.GetText();
                    if (String.IsNullOrEmpty(csvLine))
                        return;
                    string[] values = csvLine.Split(',');
    
                    if (values.Count() < 4)
                        return;
    
                    txtValue1.Text = values[0];
                    txtValue2.Text = values[1];
                    txtValue3.Text = values[2];
                    txtValue4.Text = values[3];
    
                    e.SuppressKeyPress = true;
                }
            }
        }
