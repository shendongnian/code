	private void button1_Click(object sender, EventArgs e)
        {
            String result1, result2="";
            if (radioButton1.Checked )
            {
                result1 = radioButton1.Text;
            }
            else if (radioButton2.Checked)
            {
                result1 = radioButton1.Text;
            }
            else if (radioButton3.Checked)
            {
                result1 = radioButton3.Text;
            }
	        List<string> choices = new List<string>();
            if (checkBox1.Checked)
            {
                choices.Add(checkBox1.Text);
            }
            if (checkBox2.Checked)
            {
                choices.Add(checkBox2.Text);
            }
            if (checkBox3.Checked)
            {
                choices.Add(checkBox3.Text);
            }
            textBox1.Text=String.Format("You like to shop from {0} for clothing styles like {1}", result1, String.Join(",",choices.ToArray()));
       }
