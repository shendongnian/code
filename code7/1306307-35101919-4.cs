    private void AnotherButton_Click(object sender, EventArgs e)
    {
        TextBox txt = panel1.Controls
                            .OfType<TextBox>()
                            .FirstOrDefault(x =x.Tag.ToString() == "SPEECH");
        if(txt != null)
        {
            SpVoice vc = new SpVoice();
            vc.Speak(txt.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }
        else
            MessageBox.Show("Press the create button first!");
    }
