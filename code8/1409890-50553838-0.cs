        private delegate void ToggleVoid();
        private static event ToggleVoid VisibilityToggle;
        private void Form1_Load(object sender, EventArgs e)
        {
            DependantButton TestButton = new DependantButton();
            TestButton.SetBounds(100, 100, 100, 100);
            this.Controls.Add(TestButton);
            Button ToggleButton = new Button();
            ToggleButton.SetBounds(200, 200, 100, 100);
            ToggleButton.Click += OnToggleButtonClicked;
            this.Controls.Add(ToggleButton);
        }
        private void OnToggleButtonClicked(object sender, EventArgs e)
        {
            VisibilityToggle.Invoke();
        }
        private class DependantButton : Button
        {
            public DependantButton() : base()
            {
                VisibilityToggle += ToggleVisibility;
            }
            public void ToggleVisibility()
            {
                Visible = !Visible;
            }
        }
