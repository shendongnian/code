        private void button1_Click(object sender, EventArgs e)
        {
            string[] list = { "Open", "Completed","Rescheduled", 
                                "Canceled", "Started", "Customer notified", 
                                "Do Not Move", "Needs Confirmation" };
            string binary;
            int max = (int)Math.Pow(2, list.Length);
            List<string> combo = new List<string>();
            List<string> combinations = new List<string>();
            
            for(int i = 1; i < max; i++)
            {
                binary = Convert.ToString(i, 2);
                char[] bits = binary.ToCharArray();
                Array.Reverse(bits);
                binary = new string(bits);
                combo.Clear();
                for(int x = 0; x < binary.Length; x++)
                {
                    if (binary[x] == '1')
                    {
                        combo.Add(list[x]);
                    }
                }
                combinations.Add(String.Join(", ", combo));
            }
            // ... do something with "combinations" ...
            listBox1.DataSource = null;
            listBox1.DataSource = combinations;
        }
