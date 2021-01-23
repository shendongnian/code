    private void button2_Click_1(object sender, EventArgs e) {
        int Int1;
        int Int2;
        int Product;
        string Text1;
        string Text2;
        Text2 = textBox2.Text;
        Text1 = textBox1.Text;
        listBox1.Items.Add(textBox1.Text);
        listBox1.Items.Add(textBox2.Text);
        if( int.TryParse(Text1, out Int1) && int.TryParse(Text2, out Int2)) {
            Product = Int1 * Int2;
            listBox1.Items.Add(Product);
        } else {
            listBox1.Items.Add("<incorrect input>");
        }
    }
