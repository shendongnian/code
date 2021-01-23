        private AudioSource audioSource;
        public AudioClip Scored;
        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameobject.tag == "Player")
            {
                audioSource = GetComponent<AudioSource>();
                audioSource.clip = Scored;
                audioSource.Play();
            }
    }
