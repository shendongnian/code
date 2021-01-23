    public class AudioController : Monobehaviour {
        
        void OnGUI () {
            if(GUI.Button(new Rect(10, 10, 150, 50), "Play Clip"))
                AudioPlayer.instance.PlayClip();
    
             if(GUI.Button(new Rect(10, 70, 150, 50), "Stop Clip"))
                AudioPlayer.instance.StopClip();
        }
    }
