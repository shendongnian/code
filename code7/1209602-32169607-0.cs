    public class FirstPage : MonoBehaviour {
    
        public AudioSource mySound;
    
        // Use this for initialization
        void Start () {
            var audioClip = Resources.Load<AudioClip>("05 - Listen to the Man_[plixid.com]");  //Load the AudioClip from the Resources Folder
            mySound.clip = audioClip;  //Assign it as AudioSource's clip
        }
    
        void Update () {
            if(Input.GetKeyUp(KeyCode.Space)){
                mySound.Play();
            }  //Also, I removed the extra semi-colon you had here
        }
    }
