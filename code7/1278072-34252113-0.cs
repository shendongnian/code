    private void button1_Click(object sender, EventArgs e)
    {
        string whereStatement = "";
        // ensure we have something to work with
        if (!string.IsNullOrWhiteSpace(textBox1.Text))
        {
            // Are there commas
            if (textBox1.Text.Contains(","))
            {
                string textValue = textBox1.Text.TrimEnd();
                // make sure there is no trailing commas
                if (textValue.Last() != ',')
                {
                    string[] parts = textBox1.Text.Split(',');
                    int badCount = 0;
                    int testValue = 0;
                    // see if all values are int
                    foreach (string item in parts)
                    {
                        if (!int.TryParse(item, out testValue))
                        {
                            badCount += 1;
                        }
                    }
    
                    if (badCount == 0)
                    {
                        string whereCondition = "ID = " + textValue.Replace(",", " OR ID = ");
                        whereStatement = string.Format("SELECT [Name], phno WHERE {0} FROM mytable", whereCondition);
                    }
                }
            }
            else
            {
                // one id 
                whereStatement = string.Format("SELECT [Name], phno WHERE ID = {0} FROM mytable", textBox1.Text);
            }
        }
    
        if (!string.IsNullOrWhiteSpace(whereStatement))
        {
            MessageBox.Show(whereStatement);
        }
        else
        {
            MessageBox.Show("Invald data");
        }
    }
