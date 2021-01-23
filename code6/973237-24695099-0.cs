       private void textBox1_Validated(object sender, EventArgs e)
        {
        bool FoundMatch = false;
        if(combobox1.text.contains("hardners"))
            {
                try {
                    FoundMatch = Regex.IsMatch(textBox1.text, "\\APHY\\0+\\z");
                } catch (ArgumentException ex) {
	        
                    // Syntax error in the regular expression
                }
            }
            else
            {
                try
                {
                    FoundMatch = Regex.IsMatch(textBox1.text, "\\APH\\0+\\z");
                }
                catch (ArgumentException ex)
                {
                    // Syntax error in the regular expression
                }
            }
       }
