    using UnityEngine;
    using UnityEngine.EventSystems;
    using System.Collections;
    [RequireComponent(typeof(AudioSource))]
    public class Kim : MonoBehaviour, ICardboardPointer {
        public GameObject kkhair;
        public AudioSource audio;
        void Start() {
            audio = GetComponent<AudioSource>();
        }
        public void speakKim() {
            audio.Play();
        }
        void OnGazeTriggerStart(Camera camera)
        {
            // user began pressing the trigger
        }
        void OnGazeTriggerEnd(Camera camera)
        {
            // User released the trigger
            speakKim();
        }
    }
