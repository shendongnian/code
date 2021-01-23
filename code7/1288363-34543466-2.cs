    private void Button1_Click(object sender, EventArgs e)
    {
        ComboBox1.Items.Clear();
        foreach (Groep g in Groepen.Where(g => g.NaamGroep.Contains(TextBox1.Text)))
            ComboBox1.Items.Add(g.NaamGroep);
    }
