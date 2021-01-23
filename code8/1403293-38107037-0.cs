    Button[] buttons = new Button[10]; // Let's say 10
    for (int i=0; i<buttons.Length; i++)
    {
        buttons[i] = new Button();
        buttons[i].Click += button_Click;
    }
    private void button_Click(object sender, EventArgs e)
    {
         // This method is invoked when any of the buttons is clicked
    }
