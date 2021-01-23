    using UnityEngine;
    using System.Collections;
    public class Button : MonoBehaviour
    {
        public AudioSource audio;
        public AudioClip buttonSound;
        void Update()
        {
        }
        // Changed from start(); which is not valid
        // Also, this may need to be "Start" (note the difference in casing)
        void start()
        {
	       audio = (AudioSource)AudioClip.AddComponent ("AudioSource");
	       AudioClip myAudioClip;
	       myAudioClip = (AudioClip)Resources.Load("SFX/DoNotQuestionTheAdventureVoice");
	       audio.clip = myAudioClip;
        }
	    void OnGUI ()
        {
            if (GUI.Button (new Rect (300, 300, 400, 50), "Do not question the adventure voice!")) {
            audio.Play ();
        }
    }
