    textbox1.TextChanged += ValidateInput;
    textbox2.TextChanged += ValidateInput;
    textbox3.TextChanged += ValidateInput;
   
    ...
    
    private void ValidateInput(object sender, EventArgs args)
    { 
        bool valid = true;
        foreach(var textbox in new [] { textBox1, textBox2, textBox3})
        { 
            double value;
            if (!double.TryParse(textbox.Text, out value))
            { 
                textBox.Color = Color.Red;
                valid = false;
            }
            else
                textBox.Color = Color.Black;
        }
        buttonCalculate.Enabled = valid;
    }
