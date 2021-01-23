    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    using System.Text.RegularExpressions;
    
    namespace Propress
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void richTextBox1_TextChanged(object sender, EventArgs e)
            {
                string text = richTextBox1.Text;
                ICollection<string> matches =
                    Regex.Matches(text.Replace(Environment.NewLine, ""), @"\(([^)]*)\)")
                        .Cast<Match>()
                        .Select(x => x.Groups[1].Value)
                        .ToList();
                foreach (string match in matches)
                    MessageBox.Show(match);
            }
        }
    }    
