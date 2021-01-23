    panel1.AutoScroll = true;
            Button myButton = new Button();
            myButton.Location = new Point(
               panel1.AutoScrollPosition.X,
               panel1.AutoScrollPosition.Y + (y+6));
            y += 20;
            panel1.Controls.Add(myButton);
