              int n = int.Parse(textBox7.Text); ;
                int[] numbers = new int[n];
                for (int i = 0; i < n; i++)
                {
                    numbers[i] = int.Parse(textBox1.Text);
                }
               // var array = new short[] { 4, 4, 5, 6,9 };
    
                var sum = numbers.Select(x => (int)x).Sum();
                var avg = numbers.Select(x => (int)x).Average();
                var max = numbers.Select(x => (int)x).Max();
                var min = numbers.Select(x => (int)x).Min();
    
                textBox4.Text = sum.ToString();
                textBox5.Text = avg.ToString();
                textBox2.Text = min.ToString();
                textBox3.Text = max.ToString();
