     private void buttonEQ_Click(object sender, EventArgs e)
        {
    
            string valueTWO;
            valueTWO = textBox1.Text;
            string[] s = valueTWO.Split('-');
            // value before "-"
            Console.WriteLine(s[0]);
            // value after "-"
            Console.WriteLine(s[1]);
    
        }
