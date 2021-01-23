        // Adds 10 Radiobuttons with the name "Radio <number>" 
        public Form1()
        {
            InitializeComponent();
            for (int n = 0; n < 10; n++)
            {
                // First instantiate a new RadioButton.
                RadioButton button = new RadioButton();
 
                // Now the name of the button.
                button.Text = "Radio" + n;
                // Dock the button to the top of the GroupBox (to put them in order)
                button.Dock = DockStyle.Top;
                // Add the button to the GroupBox.
                this.groupBoxRadio.Controls.Add(button);
            }
        }
