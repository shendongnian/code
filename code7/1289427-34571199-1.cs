        AudioSource output;
        public AudioClip[] songs;
        int songIndex = 0;
        void Start(){
            output = gameObject.AddComponent<AudioSource>();
        }
        public void ToggleSong(){
            songIndex++;
            output.clip = songs[songIndex % songs.Length];
            output.Play();
        }
        public void TurnOn(){
            ToggleSong();
        }
        public void TurnOff(){
            output.Stop();
        }
