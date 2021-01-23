    private void change_properties(Button button)
    {
        button.backcolor = color.darkgreen;
        button_click("A3"); //this is a method for adding A3 to a string,   
        button.enabled = false;
        nr_l++;
        textbox4.text = convert.tostring(nr_l);
    }
    private void button1_Click(object sender, EventArgs e)
    {
        change_properties(sender as Button);
        //do something else specific for button1
    }
    ....
    private void button36_Click(object sender, EventArgs e)
    {
        change_properties(sender as Button);
        //do something else specific for button36
    }
