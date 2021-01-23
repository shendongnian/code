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
                MyButton myButton = new MyButton(this);
            }
        }
        public class MyButton : Button
        {
            public static List<List<MyButton>> board { get; set; }
            public static List<MyButton> buttons { get; set; }
            const int WIDTH = 10;
            const int HEIGTH = 10;
            const int SPACE = 5;
            const int ROWS = 10;
            const int COLS = 20;
            public int row { get; set; }
            public int col { get; set; }
            public MyButton()
            {
            }
            public MyButton(Form1 form1)
            {
                board = new List<List<MyButton>>();
                buttons = new List<MyButton>();
                for (int _row = 0; _row < ROWS; _row++)
                {
                    List<MyButton> newRow = new List<MyButton>();
                    board.Add(newRow);
                    for (int _col = 0; _col < COLS; _col++)
                    {
                        MyButton newButton = new MyButton();
                        newButton.row = _row;
                        newButton.col = _col;
                        newButton.Width = WIDTH;
                        newButton.Height = HEIGTH;
                        newButton.Top = _row * (HEIGTH + SPACE);
                        newButton.Left = _col * (WIDTH + SPACE);
                        form1.Controls.Add(newButton);
                        newRow.Add(newButton);
                        buttons.Add(newButton);
                    }
                }
            }
        }
    }
