    private void Calculate()
    {
        int a = (int)(listBox1.SelectedItem as ListBoxItemThing);
        int b = int.Parse(listBox2.SelectedItem.ToString());
        textBox1.Text = (a * b).ToString();
    }
