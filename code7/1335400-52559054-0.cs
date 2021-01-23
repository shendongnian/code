    public Form1()
        {
            InitializeComponent();
            SetComponents();
        }
        void SetComponents()
        {
            foreach (Control item in Controls)
            {
                if (item is Button)
                {
                    item.Width = Size.Width / 4 - 16;
                    item.Height = Size.Height / 4;
                    item.Font = new Font(Font.FontFamily, item.Height / 5);
                }
                button1.Left = 10;
                button1.Top = 10;
                button2.Left = button1.Right + 10;
                button2.Top = button1.Top;
                button3.Left = button2.Right + 10;
                button3.Top = button2.Top;
                button4.Left = button3.Right + 10;
                button4.Top = button3.Top;
                button5.Left = button1.Left;
                button5.Top = button1.Bottom + 10;
                button6.Left = button5.Right + 10;
                button6.Top = button2.Bottom + 10;
                button7.Left = button6.Right + 10;
                button7.Top = button3.Bottom + 10;
                button8.Left = button7.Right + 10;
                button8.Top = button4.Bottom + 10;
                button9.Left = button1.Left;
                button9.Top = button5.Bottom + 10;
                button10.Left = button9.Right + 10;
                button10.Top = button6.Bottom + 10;
                button11.Left = button10.Right + 10;
                button11.Top = button7.Bottom + 10;
                button12.Left = button11.Right + 10;
                button12.Top = button8.Bottom + 10;
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            SetComponents();
        }
