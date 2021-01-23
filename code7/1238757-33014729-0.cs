        void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta > 0)
                wmpPlayer.settings.volume = activeMusic.settings.volume + 1;
            else
                wmpPlayer.settings.volume = activeMusic.settings.volume - 1;
            //to check the volume no.
            MessageBox.Show(Convert.ToString(wmpPlayer.settings.volume));
        }
