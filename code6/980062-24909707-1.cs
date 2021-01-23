    void SetClickEvents()
    {
        // Add the listeners
        btn1.Click += new EventHandler(Button_Click);
        btn2.Click += new EventHandler(Button_Click);
        btn3.Click += new EventHandler(Button_Click);
        // ... repeat for 49, or even loop
    }
    void Button_Click(Object sender, EventArgs e)
    {
      // DO your adding
    }
