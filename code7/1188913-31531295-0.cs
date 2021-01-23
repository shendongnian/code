    for (int i = 0; i < listBox2.Items.Count; i++)
    {
        try
        {
            messagebox(listBox2.Items[i]);        
            messagebox(listBox1.Items[i]);
        }
        catch (Exception) { }
    }
