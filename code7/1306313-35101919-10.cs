    var speechBoxes = panel1.Controls
                      .OfType<TextBox>()
                      .Where(x =x.Tag.ToString() == "SPEECH");
    if (speechBoxes != null)
    {
        SpVoice vc = new SpVoice();
        foreach(TextBox txt in speechBoxes)
        {
            vc.Speak(txt.Text, SpeechVoiceSpeakFlags.SVSFDefault);
            // Not sure if you need also to add this call ....
            vc.WaitUntilDone(10000);
        }
    }
