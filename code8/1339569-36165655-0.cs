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
            const int ROWS = 10;
            const int COLS = 15;
            const int WIDTH = 20;
            const int HEIGHT = 20;
            const int SPACE = 10;
            List<List<MyButton>> buttons = new List<List<MyButton>>();
            public Form1()
            {
                InitializeComponent();
                for (int row = 0; row < ROWS; row++)
                {
                    List<MyButton> newRow = new List<MyButton>();
                    buttons.Add(newRow);
                    for (int col = 0; col < COLS; col++)
                    {
                        MyButton newButton = new MyButton();
                        newRow.Add(newButton);
                        newButton.Width = WIDTH;
                        newButton.Height = HEIGHT;
                        newButton.Left = col * (WIDTH + SPACE);
                        newButton.Top = row * (HEIGHT + SPACE);
                        newButton.row = row;
                        newButton.col = col;
                        panel1.Controls.Add(newButton);
                    }
                }
            }
        }
        public class MyButton : Button
        {
            public int row { get; set; }
            public int col { get; set; }
        }
    }
