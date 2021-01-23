    private void btnSort_Click(object sender, EventArgs e)
            {
                int num1, num2, num3, num4, num5, num6, num7, num8, num9, num10;
                num1 = int.Parse(textBox1.Text);
                num2 = int.Parse(textBox2.Text);
                num3 = int.Parse(textBox3.Text);
                num4 = int.Parse(textBox4.Text);
                num5 = int.Parse(textBox5.Text);
                num6 = int.Parse(textBox6.Text);
                num7 = int.Parse(textBox7.Text);
                num8 = int.Parse(textBox8.Text);
                num9 = int.Parse(textBox9.Text);
                num10 = int.Parse(textBox10.Text);
    
                var inputList = new List<int>();
                inputList.Add(num1);
                inputList.Add(num2);
                inputList.Add(num3);
                inputList.Add(num4);
                inputList.Add(num5);
                inputList.Add(num6);
                inputList.Add(num7);
                inputList.Add(num8);
                inputList.Add(num9);
                inputList.Add(num10);
    
            inputList.OrderBy(order =>order);
            inputList.OrderByDescending(order =>order);
                
        }
