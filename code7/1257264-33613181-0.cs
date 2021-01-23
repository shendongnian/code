    private async Task MyThreadProcedureAsync(string fileName)
    {
        // do something really slow with fileName and return void
    }
    protected async void Button1_Click(object sender, EventArgs e)
    {
        string fileName = this.BrowseForFile();
        if (!String.IsNullOrEmpty(fileName))
        {
            var myTask = Task.Run( () => MyThreadProcedureAsync(fileName))
            // if desired do other things.
            // before returning make sure the task is ready:
            await myTask;
            // during this wait the UI keeps responsive
        }
    }
    private string BrowseForFileName()
    {
        using (var dlg = new System.Windows.Forms.OpenFileDialog())
        {
            // if needed set some properties; show the dialog:
            var dlgResult = dlg.ShowDialog(this);
            if (dlgResult == System.Windows.Forms.DialogResult.OK)
            {
                return dlg.FileName;
            }
            else
            {
                return null;
            }
        }
    }
