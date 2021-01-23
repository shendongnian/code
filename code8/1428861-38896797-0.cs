    public static string new_item;
    private void btn1_Click(object sender, EventArgs e)
    {
        Form2 f2= new Form2();
        f2.ShowDialog();
        comoBox1.Items.Add(new_item);  //this is missing in your code
    }
