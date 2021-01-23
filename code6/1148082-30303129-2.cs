    private async void button1_Click(object sender, EventArgs e)
    {
      label1.Text = "Test";
      await MyMethodAsync();
    }
    public async Task MyMethodAsync()
    {
      label1.Text = "";
      await ...; // "lot of IO and stuff"
      label1.Text = "Done";
    }
