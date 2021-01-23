        private void playMusic(int index)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (_waveOutDevice.PlaybackState != PlaybackState.Stopped)
                    stopMusic();
                _audioFileReader = new AudioFileReader(listMusic.Items[index].SubItems[0].Text); 
                _waveOutDevice.Init(_audioFileReader);
                _waveOutDevice.Play();
                btnPlayCtrl.Text = "II";
                nowIndex = index;
                _manual_stop = false;
            });
        }
