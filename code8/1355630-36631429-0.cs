    private void button1_Click(object sender, EventArgs e)
    {
        int[] m = new int[1000];
        int n = textBox1.Lines.Lenght;
        int i;
        int k = 0;
        int sum = 0;
        int product = 1;
        int average = 0;
        int min = Int32.MaxValue;   // will hold min value
        int max = Int32.MinValue;   // will hold max value
    
        for (i = 0; i < n; i++)
        {
            try 
            {
                m[k] = Convert.ToInt32(textBox1.Lines[i]);
                sum = sum + m[k];
                product = product * m[k];
                if (m[k] < min)
                  min = m[k];
                if (m[k] > max)
                  max = m[k];
            }     
            catch 
            {
                MessageBox.Show("Буквы нельзя!!");
                k++;
            }
        }
        average = sum / n;  //Computing average here is more efficient
        label10.Text = n.ToString();
        label11.Text = sum.ToString();
        label12.Text = product.ToString();
        label13.Text = average.ToString();     
    }
