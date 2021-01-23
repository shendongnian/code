    private async void StartRecognizing_Click(object sender, RoutedEventArgs e)
    {
        // Create an instance of SpeechRecognizer.
        var speechRecognizer = new Windows.Media.SpeechRecognition.SpeechRecognizer();
    
        // Compile the dictation grammar by default.
        await speechRecognizer.CompileConstraintsAsync();
    
        // Start recognition.
        Windows.Media.SpeechRecognition.SpeechRecognitionResult speechRecognitionResult = await speechRecognizer.RecognizeWithUIAsync();
    
        // Do something with the recognition result.
        var messageDialog = new Windows.UI.Popups.MessageDialog(speechRecognitionResult.Text, "Text spoken");
        await messageDialog.ShowAsync();
    }
