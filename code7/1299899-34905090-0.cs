    IEnumerable OnTriggerEnter(Collider other) 
    {
        if (other.gameObject.CompareTag ( "Pick Up"))
        {
            other.gameObject.SetActive (false);
            count = count + 1;
            yield return SetCountText ();
        }
    }
    IEnumerable SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 1)
        {
            winText.text = "You Win!";
            yield return new WaitForSeconds(5); // Wait for seconds before changing level
            Application.LoadLevel(1);
        }
    }
