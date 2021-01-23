    public async Task ShowAsync(string message, Dictionary<string, Action> commands)
    {
        var translatedCommands = new Dictionary<string, Action>();
        foreach (var element in commands)
            translatedCommands.Add(Translate(element.Key), element.Value);
        var buttons = new string[translatedCommands.Keys.Count];
        translatedCommands.Keys.CopyTo(buttons, 0);
        string selectedElement = null;
        if (Device.OS == TargetPlatform.Android)
        {
            Task<string> Result = null;
            Device.BeginInvokeOnMainThread(() =>
            {
                Result = App.Current.MainPage.DisplayActionSheet(message, null, null, buttons);
            });
            selectedElement = await Result;
        }
        else if (Device.OS == TargetPlatform.Windows || Device.OS == TargetPlatform.WinPhone)
        {
            selectedElement = await App.Current.MainPage.DisplayActionSheet(message, null, null, buttons);
        }
        else
            throw new NotImplementedException("Only implemented for Android and Windows (Phone)");
        if (selectedElement == null)
            return;
        translatedCommands[selectedElement]?.Invoke();
    }
