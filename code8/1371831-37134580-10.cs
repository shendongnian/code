private int calculateSum(string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8)
    Now the contract is *clear*: `calculateSum` is a function that takes 8 string arguments and somehow produces and returns a result.
    The implementation of the method would be:
        private int calculateSum(string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8)
        {
            int A, B, C, D, E, F, G, H;
            A = int.Parse(TextBox1);
            B = int.Parse(TextBox2);
            C = int.Parse(TextBox3);
            D = int.Parse(TextBox4);
            E = int.Parse(TextBox5);
            F = int.Parse(TextBox6);
            G = int.Parse(TextBox7);
            H = int.Parse(TextBox8);
            return A + B + C + D + E + F + G + H;
        }
    And now you'd call it as follows;
        private void button7_Click(object sender, EventArgs e)
        {
             lblTotal1.Text = calculateSum(textBox1.Text, textBox2.Text, ...);
        }
