    private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            // don't pass the enter key on to the DGV:
            e.Handled = true;
            // now store or proecess the index:
            Console.WriteLine(dataGridView1.CurrentRow + "");
        }            
    }
