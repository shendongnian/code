       StreamReader tx;
       if (textBox1.Text != "")
       {
          tx = new StreamReader(textBox1.Text);
       }
       else
       {
          tx = new StreamReader("new.txt");
       }
