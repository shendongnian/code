    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace Buttons
    {
        public partial class Form1 : Form
        {
            const int ROWS = 5;
            const int COLS = 10;
            
            public Form1()
            {
                InitializeComponent();
                this.Load += new System.EventHandler(this.Form1_Load);
            }
            public void Form1_Load(object sender, EventArgs e)
            {
                new MyButton(ROWS, COLS, this);
            }
        }
        public class MyButton : Button
        {
            const int WIDTH = 50;
            const int HEIGHT = 50;
            const int SPACE = 5;
            const int BORDER = 20;
            public static List<List<MyButton>> buttons { get; set; }
            public static List<MyButton> buttonList { get; set; }
            public Form1 form1;
            public int row { get; set; }
            public int col { get; set; }
            public MyButton()
            {
            }
            public MyButton(int rows, int cols, Form1 form1)
            {
                buttons = new List<List<MyButton>>();
                buttonList = new List<MyButton>();
                this.form1 = form1;
                for (int row = 0; row < rows; row++)
                {
                    List<MyButton> newRow = new List<MyButton>();
                    buttons.Add(newRow);
                    for (int col = 0; col < cols; col++)
                    {
                        MyButton newButton = new MyButton();
                        newButton.Height = HEIGHT;
                        newButton.Width = WIDTH;
                        newButton.Top = row * (HEIGHT + SPACE) + BORDER;
                        newButton.Left = col * (WIDTH + SPACE) + BORDER;
                        newButton.row = row;
                        newButton.col = col;
                        newRow.Add(newButton);
                        buttonList.Add(newButton);
                        newButton.Click += new System.EventHandler(Button_Click);
                        form1.Controls.Add(newButton);
                    }
                }
            }
            public void Button_Click(object sender, EventArgs e)
            {
                MyButton button = sender as MyButton;
                MessageBox.Show(string.Format("Pressed Button Row {0} Column {1}", button.row, button.col));
            }
        }
    }
