        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int a, b;
                bool prime = true;
                List<int> results = new List<int>();
                a = int.Parse(textBox1.Text);
                b = int.Parse(textBox2.Text);
                int i = a;
                while (i < b)
                {
                    for (int j = 2; j <= i; j++)
                    {
                        if (i != j && i % j == 0)
                        {
                            prime = false;
                            break;
                        }
                    }
                    if (prime)
                    {
                        results.Add(i);
                    }
                    prime = true;
                    i++;
                }
                label1.Text = string.Join(", ", results);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
