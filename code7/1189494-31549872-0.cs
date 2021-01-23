    private async void ucDeviceInsert_Load(object sender, EventArgs e)
    {
      pbImage.Image = Properties.Resources.Remove;
      await AVeryLongRunningProccess();
      pbImage.Image = Properties.Resources.Insert;
      btnNext.Visible = true;
      tmrDeviceInsert.Enabled = true;
      tmrDeviceInsert.Start();
    }
