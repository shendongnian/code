    int x = 35;
    int cleft = 0;
    foreach (var item in itemLi)
    {
        Button myButton = new Button();
        myButton.Text = itemDetail[0].ToString();
        myButton.Top = cleft * 80;
        myButton.Left = 70;
        myButton.Location = new Point(x, cleft);
        myButton.Size = new Size(100, 60);
        tabPage1.Controls.Add(myButton);
        
        x += 134;
        // Check if x is greater than form size,
        // If so, resets x, and increments cleft
        if (x >= 537)
        {
            x == 35;
            cleft += 15
        }
    }
