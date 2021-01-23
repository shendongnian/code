    private void button1_Click(object sender, EventArgs e)
    {
        string sPath; //Declaration pattern: Variable Type followed by Name
        System.Media.SoundPlayer mySound; //if you're not using namespace full path
        sPath = "Location of where I have the sound file.wmv";
        mySound = new Media.SoundPlayer(sPath);
        mySOund.Play();
    }
