    private void QuestionAudioPlayer_PlaybackStopped(object sender, EventArgs e)
    {
        if( this.InvokeRequired )
        {
            // We're in an asynchronous context...
            MethodInvoker del = delegate
                {
                    this.QuestionAudioPlayer_PlaybackStopped(sender, e);
                };
            this.Invoke(del);
            return;
        }
        // This will be executed in the synchronous context:
        btnPlayQuestionAudio.Text = "?";
    }
