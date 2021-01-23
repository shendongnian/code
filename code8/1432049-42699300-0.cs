     public void buttonActivated()
     { 
       audio.Dispatcher.Invoke(() =>
                {
                    audio.Play();
                });
     }
