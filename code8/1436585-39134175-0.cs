    private async void button6_Click(object sender, EventArgs e)
    {
        GetNumber gtn = new GetNumber();
        gtn.Show();
        await Task.Delay(6000);
        gtn.Hide();
        gtn = null;
    }
