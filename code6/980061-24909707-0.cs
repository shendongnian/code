    void SetClickEvents()
    {
        // Add the listeners
        btn1.Click += new EventHandler(button_click);
        btn2.Click += new EventHandler(button_click);
        btn3.Click += new EventHandler(button_click);
        // ... repeat for 49, or even loop
    }
    void Button_Click(Object sender, EventArgs e)
    {
      // DO your adding
    }
