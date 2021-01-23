    using UnityEngine;
    using System.Collections;
    public class ScorePoint : MonoBehaviour
    {
        private AudioSource audioSource;
        public AudioClip Scored;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = Scored;
                audioSource.Play();
            }
        }
    }
