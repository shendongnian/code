    private void button1_Click(object sender, EventArgs e)
    {
        // Define your variables
        int amount, length, width;
        if(!Int32.TryParse(amount.Text, out amount))
        {
             // Amount was not an integer, do something here
        }
        if(!Int32.TryParse(length.Text, out length))
        {
             // Length was not an integer, do something here
        }
        if(!Int32.TryParse(width.Text, out width))
        {
             // Width was not an integer, do something here
        }
        // At this point, you can calculate your result
        total.Text = Convert.ToString(length * width * amount);
    }
