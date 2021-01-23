    int song_index=0; // index of the song 
        private void player_play()
                {
                    outputdevice.PlaybackStopped += playbackstopped;
                    if (outputdevice.PlaybackState != PlaybackState.Paused)
                    {
                        to_play = playlist.Rows[song_index].Cells[0].Value.ToString();
                        audiofile = new AudioFileReader(to_play);
                        outputdevice.Init(audiofile);
                    }   
         outputdevice.Play();
        }
        // this event occur when the playing file has ended 
         private void playbackstopped(object sender, StoppedEventArgs e)
                {
                 song_index++; // play the next file 
                 player_play();
                }
