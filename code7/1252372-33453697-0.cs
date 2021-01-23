    double c;
    
    if (textBox2.Text != "")
    {
    string h = textBox2.Text;
    c = double.Parse(h);
    }
    else if (textBox2.Text == "")
    {
    c = 0;
    }
    // else error message
    
    //Delta
    double delta = (Math.Pow(b, 2)) - (4 * a * c);
    string dtxt = Convert.ToString(delta);
    
    label5.Text = dtxt;
