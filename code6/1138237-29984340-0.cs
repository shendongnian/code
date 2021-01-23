    private void button1_Click(object sender, EventArgs e)
            {
                double outValue;
                if (double.TryParse(textBox1.Text, out outValue))
                {
                    var answer = Math.PI * Math.Pow(outValue, 2);
                    textBox2.Text = answer.ToString("#.##");
                }
            }
