        RaycastHit[] hits;
        hits = Physics.RaycastAll( transform.position, transform.forward, 100.0F );
        List<GameObject> gameObjectsHit = new List<GameObject>();
        //or GameObject[] gameObjects= new GameObject[hits.Length]
        for( int i = 0; i < hits.Length; i++ ) {
          RaycastHit hit = hits[i];
          gameObjectsHit.Add( hits[i].transform.gameObject );
          //or gameObjects[i] = hits[i].transform.gameObject
        }
        //you now have a list or array of hit gameobjects
