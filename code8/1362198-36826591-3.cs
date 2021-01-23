    public class Sounds
    {
        SoundPlayer player = new SoundPlayer();
    
        public void Play(string file)
        {
            player.Stop();
            player.SoundLocation = file;
            player.Play();
        }
    }
