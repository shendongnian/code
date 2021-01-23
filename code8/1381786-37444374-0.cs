    private async void btnCreateFile_Click(object sender, EventArgs e)
    {
      Cursor = Cursors.WaitCursor;
      dtLossRatio.Clear();
      lblProgress.Visible = true;
      lblProgress.Text = "Building ETL A...";
      pbProcessWait.Visible = true;
      pbProcessWait.Location = new Point(420, 413);
      await logic.MethodAAsync(DateTimePicker1.Value, DateTimePicker2.Value);
      Cursor = Cursors.WaitCursor;
      dtLossRatio.Clear();
      lblProgress.Visible = true;
      lblProgress.Text = "Building ETL B...";
      pbProcessWait.Visible = true;
      pbProcessWait.Location = new Point(456, 413);
      await logic.MethodBAsync(DateTimePicker3.Value, DateTimePicker4.Value);
    }
