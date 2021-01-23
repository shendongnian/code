    private void button_Click(object sender, EventArgs e)
    {
        Button btn = sender as Button;
        int i = Convert.ToInt32(btn.Name.Replace("button", ""));
    
        Procedure(i);
    
    }
