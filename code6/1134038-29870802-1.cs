    if(Physics2D.OverlapArea(_overlapA,_overlapB,layermask,Mathf.Infinity,Mathf.Infinity)==null){
        _position=Camera.main.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(R1,R2,10));
    GameObject newGameObject = Instantiate(Resources.Load("Square",typeof (GameObject)),_position,Quaternion.identity);
        mySpawns.Add(newGameObject);
        }
        else{
            Debug.Log("avoided collision");
        }
       // Take note that if you miss a cast for some reason, just add "as GameObject" at the end to DownCast it.
