    public Form1()
        {
            InitializeComponent();
            int top = 5;
            int left = 5;
            var buttons = new Button[10];
            for (int i = 0; i < 10; i++)
            {
                Button button = new Button();
                button.Height = 50;
                button.Left = left;
                button.Top = top;
                this.Controls.Add(button);
                left += button.Width + 2;
                buttons[i] = button;
            }
        }
