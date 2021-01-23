        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
           if (e.KeyCode == Keys.Enter && pbPlayer.Bounds.IntersectsWith(pnlSave.Bounds))
              {
                string timePlayed;
                stopWatch.Stop();
                TimeSpam totalTime = stopWatch.Elapsed + Properties.Settings.savedPlayTime;
                timePlayed = string.Format("{0:D2}:{1:D2}:{2:D2}", Properties.Settings.Default.savedPlayTime.Hours, Properties.Settings.Default.savedPlayTime.Minutes, Properties.Settings.Default.savedPlayTime.Seconds);
                if (MessageBox.Show("Are you sure you wish to overwrite your last save of " + timePlayed + "?")== DialogResult.OK)
                   {
                     Properties.Settings.Default.savedPlayTime = totalTime;
                     Properties.Settings.Default.Save();
                     stopWatch.Reset();
                     MessageBox.Show("Game saved!");
                    }
                stopWatch.Start();
              }
        }
