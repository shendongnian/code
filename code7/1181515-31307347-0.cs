        void InitializeButtons()
        {
            Button btnNum1 = new Button();
            btnNum1.Text = "1";
            btnNum1.Tag = 1;
            //Button 2..8 goes here
            Button btnNum9 = new Button();
            btnNum9.Text = "9";
            btnNum9.Tag = 9;
            Button[] buttons = new Button[]{
                btnNum1, btnNum2, btnNum3, btnNum4, btnNum5, btnNum6, btnNum7, btnNum8, btnNum9
            };
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Click += Button_Click;
            }
        }
        void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int value = (int)button.Tag;
            //Do something with value
        }
