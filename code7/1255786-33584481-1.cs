                void Button1Click(object sender, EventArgs e)
                    {
                       string divider = ",";
    
                       if(textBox2.Text == "") // first click.
                       {
                              textBox3.Text = textBox1.Text;
                              divider = "";
                       }
                       int pos = textBox3.Text.IndexOf(",");
                       if(pos > -1)
                       {
                            textBox2.Text = textBox2.Text + divider + textBox3.Text.Substring(0, pos);
                            textBox3.Text = textBox3.Text.Substring(pos + 1);
                       }
                       else if (textBox3.Text != "" )  // last one
                       {
                            textBox2.Text = textBox2.Text + divider + textBox3.Text;
                            textBox3.Text = "";
            
                        }
                    }
