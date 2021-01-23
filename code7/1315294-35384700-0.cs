    new System.Threading.Thread(() => {
            var c = new System.Windows.Media.MediaPlayer();
            c.Open(new System.Uri(@"..\..\Soundtracks\The Boy Who Shattered Time.wav"));
            c.PlayLooping();
        }).Start();
    
    
    new System.Threading.Thread(() => {
            var c = new System.Windows.Media.MediaPlayer();
            c.Open(new System.Uri(@"..\..\Soundtracks\demacia.wav));
            c.Play();
        }).Start();
