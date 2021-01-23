    private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Multiline = true;
            textBox2.Multiline = true;
            textBox3.Multiline = true;
            StringBuilder sb1 = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();
           var lines =   File.ReadAllLines("D:\\sample.txt");
           foreach (var line in lines) 
           {
    
               var splits = line.Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
               if (splits.Length > 2) {
                   sb1.Append(splits[0] + Environment.NewLine);
                   sb2.Append(splits[1] + Environment.NewLine);
                   sb3.Append(splits[2] + Environment.NewLine);
               }
                
    
           }
           textBox1.Text = sb1.ToString();
           textBox2.Text = sb2.ToString();
           textBox3.Text = sb3.ToString();
        }
