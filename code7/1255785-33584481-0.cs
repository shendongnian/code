        void Button1Click(object sender, EventArgs e)
            {
    
               int pos = textBox3.Text.IndexOf(",");
               if(pos > -1)
               {
                    textBox2.Text = textBox2.Text + "," + textBox3.Text.Substring(0, pos);
                    textBox3.Text = textBox3.Text.Substring(pos + 1);
               }
               else if (textBox3.Text != "" )  // last one
               {
                    textBox2.Text = textBox2.Text + "," + textBox3.Text;
                    textBox3.Text = "";
    
                }
            }
