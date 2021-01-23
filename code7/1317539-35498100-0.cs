    private string allitem;
    
    private void ToSpeechButton_Click(object sender, RoutedEventArgs e)
    {
        foreach (var item in listBox.Items)
        {
            var txt = item as ListBoxItem;
            allitem += txt.Content.ToString() + "<break time='500ms'/>";
        }
        readText(allitem);
    }
    
    private async void readText(string mytext)
    {
        MediaElement mediaplayer = new MediaElement();
        using (var speech = new SpeechSynthesizer())
        {
            speech.Voice = SpeechSynthesizer.AllVoices.First(gender => gender.Gender == VoiceGender.Female);
            string ssml = @"<speak version='1.0' " + "xmlns='http://www.w3.org/2001/10/synthesis' xml:lang='en-US'>" + allitem + "</speak>";
            SpeechSynthesisStream stream = await speech.SynthesizeSsmlToStreamAsync(ssml);
            mediaplayer.SetSource(stream, stream.ContentType);
            mediaplayer.Play();
        }
    }
