    async void btnDoStuff_Click(object sender, EventArgs e)
    {
      lblProgress.Text = "Calculating...";
      var result = await DoTheUltraHardStuff();
      lblProgress.Text = "Done! The result is " + result;
    }
