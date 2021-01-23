    if(Input.GetMouseButton(0))
    {
        if(gm)
        {
            gm.GetComponent<GameObject>();
            gm.transform.position=new Vector3(Input.mousePosition.x,Input.mousePosition.y,1);
        }
    }
