    void OnTriggerEnter(Collider other)
     {
         if (other.tag == "Pick Up") 
         {
             if (!isPlayed) {
                 source.Play ();
                 isPlayed = true;
             }
         }
         if (other.gameObject.CompareTag ("Pick Up"))
         {
             other.gameObject.SetActive (true);
             count = count + 1;
             SetCountText ();
             StartCoroutine(waitForSound(other)); //Start Coroutine
         }
     }
   
     IEnumerator waitForSound(Collider other)
        {
            //Wait Until Sound has finished playing
            while (source.isPlaying)
            {
                yield return null;
            }
            
           //Auidio has finished playing, disable GameObject
            other.gameObject.SetActive(false);
        }
