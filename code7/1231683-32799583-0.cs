    private IList<Button> addedButtons = new List<Button>();
    private void createbuttons() {
        int tot = 0;
        int x = 100;
        int y = 100;
        while(tot < 9) {
            string buttonsname = (tot + "button").ToString();
            Button creating  = new Button();
            creating.Name = buttonsname;
            creating.Size = new Size(100, 100);
            creating.Click += delegate {
                MessageBox.Show("You clicked me!");
            };
            creating.Text = buttonsname;
            if(x > 300) {
                y += 100;
                x = 100;
            }
            creating.Location = new Point(x, y);
            addedButtons.Add(creating); // Save the button for future reference
            Controls.Add(creating);
            tot += 1;
            x += 100;
        }
    }
