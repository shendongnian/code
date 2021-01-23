    private async void ExecuteSaveSoundAs(string soundPath)
        {
            var file = await ApplicationData.Current.LocalFolder.GetFileAsync(SavePath);
            FileSavePicker savePicker = new FileSavePicker();
            savePicker.SuggestedSaveFile = file;
            savePicker.FileTypeChoices.Add("MP3", new List<string>() { ".mp3" });
            savePicker.ContinuationData.Add("SourceSound", SavePath);
            savePicker.SuggestedFileName = this.Title;
            savePicker.PickSaveFileAndContinue();
        }
