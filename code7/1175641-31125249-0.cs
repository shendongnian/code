    System.Random rnd = new System.Random (); // from here is deciding on the position of the spawn after one has been spawned
        float num = rnd.Range (0, 1); //random number between 0 and 1
        if (num < .5f) {
            switchSpawning = false;
            Debug.Log ("False");
            transform.position = spawnPosition;
        } else {
            switchSpawning = true;
            Debug.Log ("True");
            transform.position = spawnPosition2;
        }
