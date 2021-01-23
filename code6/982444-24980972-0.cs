       using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        using System.Windows.Forms;
        
        namespace ScrollLabelTest
        {
            public partial class DisplayLockedThreads : Form
            {
                public DisplayLockedThreads()
                {
                    InitializeComponent();
        
                }
        
                private void DisplayLockedThreads_Load(object sender, EventArgs e)
                {
                   richTextBox1.Text = String.Join(Environment.NewLine, ListsExtractions.text1 );    
                }
            }
        }
