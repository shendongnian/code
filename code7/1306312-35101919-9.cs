    private void btnAdd_Click(object sender, EventArgs e)
    {
        TextBox txt = panel1.Controls
                            .OfType<TextBox>()
                            .FirstOrDefault(x =x.Tag.ToString() == "SPEECH");
        if (txt != null)
        {
            SpVoice vc = new SpVoice();
            vc.Speak(txt.Text, SpeechVoiceSpeakFlags.SVSFDefault);
        }
        else
        {
            TextBox textbox = new TextBox();
            .....
            textbox.Name = "textbox_" + (count + 1);
            textbox.Tag = "SPEECH";
            ....
            panel1.Controls.Add(textbox);
        }
    }
