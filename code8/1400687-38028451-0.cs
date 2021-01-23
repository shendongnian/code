    public void SomeMehthod()
    {
        Button btn1 = new Button();
        Button btn2 = new Button();
        Button btn3 = new Button();
    
        // Your button-array
        Button[] btns = new Button[]
        {
            btn1,
            btn2,
            btn3
        };
    
        foreach(Button btn in btns)
        {
            // For each button setup the same method to fire on click
            btn.Click += new EventHandler(ButtonClicked);
        }
    }
    
    private void ButtonClicked(Object sender, EventArgs e)
    {
        // This will fire on any button from the array
        // You can switch on the name, or location or anything else
        switch((sender as Button).Name)
        {
            case "btn1":
                // Do something
                break;
            case "btn2":
                // Do something
                break;
            case "btn3":
                // Do something
                break;
        }
    }
