         foreach(GameObject check in mySpawns)
             {
                vector2 MyX = check.Collider2D.transform.x;
                vector2 MyY = check.Collider2D.transform.y;                       if(Physics2D.OverlapArea(MyX,MyY,layermask,Mathf.Infinity,Mathf.Infinity)==null){
        _position=Camera.main.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(R1,R2,10));
              GameObject newGameObject = Instantiate(Resources.Load("Square",typeof (GameObject)),_position,Quaternion.identity);
        mySpawns.Add(newGameObject);
        }
          else   {
               Debug.Log("avoided collision");
           }
        }
