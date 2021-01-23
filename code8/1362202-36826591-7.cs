    public class MyThing
    {
        Sounds sounds = new Sounds();
        string SelectedFile;
    
        public void OnPlayClick()
        {
            sounds.PlayFile(SelectedFile);
        }
    }
