        public Form1()
        {
            InitializeComponent();
            // adorn one Button with a Badge Label:
            Adorner.AddBadgeTo(button1, "123");
            // if you want to you can add a click action:
            Adorner.SetClickAction(button1, dobidoo);
        }
        // a test action
        void dobidoo(Control ctl)
        {
            Console.WriteLine("You have clicked on :" + ctl.Text);
        }
