    void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.CompareTag ( "Pick Up"))
            {
                other.gameObject.SetActive (false);
                count = count + 1;
                StartCoroutine(SetCountText ());
            }
        }
    
        IEnumerator SetCountText ()
        {
            countText.text = "Count: " + count.ToString ();
            if (count >= 1)
            {
                winText.text = "You Win!";
                yield return new WaitForSeconds(1f);
                Application.LoadLevel(1);
            }
        }
