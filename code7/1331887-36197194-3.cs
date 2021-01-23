    private void __welcomeTimer_Tick(object sender, object e)
            {
    
    
    
                if (fvWelcome.SelectedIndex < fvWelcome.Items.Count - 1)
                {
    
    
                    fvWelcome.SelectedIndex++;
                    FlpVOpacity.Seek(TimeSpan.Zero);
    
                }
    
                else
                {
                    //_welcomeFade.Stop();
                    _welcomeTimer.Stop();
                    StartVideos();
                }
    
    
            }
