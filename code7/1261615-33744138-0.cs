    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            const int ROW_TEXTBOX = 5;
            const int COL_TEXTBOX = 6;
            const int TEXTBOX_WIDTH = 100;
            const int TEXTBOX_HEIGHT = 30;
            const int SPACING = 20;
            List<List<TextBox>> textboxes = new List<List<TextBox>>();
            private void button1_Click(object sender, EventArgs e)
            {
                for (int row = 0; row < ROW_TEXTBOX; row++)
                {
                    List<TextBox> newRow = new List<TextBox>();
                    textboxes.Add(newRow);
                    for (int col = 0; col < COL_TEXTBOX; col++)
                    {
                        TextBox newbox = new TextBox();
                        newbox.Width = TEXTBOX_WIDTH;
                        newbox.Height = TEXTBOX_HEIGHT;
                        newbox.Top = (row * (TEXTBOX_HEIGHT + SPACING)) + SPACING;
                        newbox.Left = (col * (TEXTBOX_WIDTH + SPACING)) + SPACING;
                        newRow.Add(newbox);
                        this.Controls.Add(newbox);
                    }
                }
            }
        }
    }
    ​
