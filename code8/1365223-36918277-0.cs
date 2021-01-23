    using System.Linq;
        namespace Running_Total
        {
            public partial class Form1 : Form
            {
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void btnDisplay_Click(object sender, EventArgs e)
                {
                    int len, num;
                    if (int.TryParse(txtArrayValues.Text, out len) &&
    int.TryParse(txtInput.Text, out num))
                    {
                        lblDisplay.Text = string.Join(",", new string[len].Select(x => txtInput.Text));
                    }
                }
            }
        }
