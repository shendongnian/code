      private void button1_Click(object sender, EventArgs e)
        {
            List<string> family = new List<string>();
            family.Add(textBox1.Text);
            family.Add(textBox2.Text);
            family.Add(textBox3.Text);
            family.ToArray();
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\OEM\Desktop\stackoverflow\test.txt"))
            {
                foreach (string line in family)
                {                   
                        file.WriteLine(line);
                }
            }
            string[] familyout = System.IO.File.ReadAllLines(@"C:\Users\OEM\Desktop\stackoverflow\test.txt");
            /*  this works just fine unless you have alot of labels, the code not commented out below this works better
            label1.Text = familyout[0];
            label2.Text = familyout[1];
            label3.Text = familyout[2];
            */
            
            int i = 0;
            foreach (Control lbl in this.Controls)
            {
                if (lbl is Label)
                {
                    lbl.Text = familyout[i];
                    i++;
                }
            }
        }
