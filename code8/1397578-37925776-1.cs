    public partial class Form1 : Form
    {
        OpenFileDialog dialog1 = new OpenFileDialog();
        
        public void browseSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog1.Title = "Browse to find sound file to play";
            dialog1.InitialDirectory = @"c:\";
            dialog1.Filter = "Wav Files (*.wav)|*.wav";
            dialog1.FilterIndex = 2;
            dialog1.RestoreDirectory = true;
            //PlaySound(dialog1.FileName, new System.IntPtr(), PlaySoundFlags.SND_SYNC);             
        }
        public void alert_sound(object source, ElapsedEventArgs e)
        {
            MessageBox.Show("Alert Sound ding ding ding");
            //PlaySound(dialog1.FileName, new System.IntPtr(), Form1.PlaySoundFlags.SND_SYNC);
        alert_timer.Stop();
        }
    }
