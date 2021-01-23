    async void SaveButtonClick(object sender, EventArgs e)
    {
        if (SaveFileDialog.ShowDialog() == DialogResult.OK)
        {
            using (var progressWindow = new ProgressForm())
            {
                progressWindow.SetPercentageDone(0);
                await progressWindow.ShowDialogAsync(this);
                var path = SaveFileDialog.FileName;
                var progress = new Progress<int>(progressWindow.SetPercentageDone);
                await Task.Run(() => Save(path, progress));
            }
        }
    }
    
    static void Save(string path, IProgress<int> progress)
    {
        // as in Stephen's answer
    }
