    private async void speakButton_Click(object sender, RoutedEventArgs e)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            await synth.SpeakTextAsync(App.ViewModel.Problems[index].Name);
        }
