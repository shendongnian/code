    Public GameObject spawnObject;
    void Update ()
    {
        DragObject (spawnObject);
    }
    void DragObject (GameObject item)
    {
         if ( input.GetMouseButtonDown ())
         {
               Vector3 pos = input.mousePosition;
            
                if (theItem == null)
                {
                       GameObject theItem = Instantiate (item, pos, new Quaternion (0f, 0f, 0f, 0f)) as GameObject;
                }
                if (theItem != null)
                {
                       theItem.transform.position = pos;
                }
          }
    }
