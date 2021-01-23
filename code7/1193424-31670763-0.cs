    int num1 = int.Parse(TextBox1.Text);
            
    double num2 = double.Parse(TextBox2.Text.Replace(".", ",")); // <---- 
            
    int num3 = int.Parse(TextBox3.Text;);
    soln1 = (int)(num1 * num2 * num3); // <----
    MessageBox.Show(soln1.ToString());
