    private void button1_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            A =  listBox1.Items[i].ToString();
            for (int j = 0; j < listBox2.Items.Count; j++)
            {
                B = listBox2.Items[j].ToString();
                listBox3.Items.Add(A + ": " + B);
            }
        }
    }
