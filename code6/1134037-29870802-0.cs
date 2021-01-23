        if(Physics2D.OverlapArea(_overlapA,_overlapB,layermask,Mathf.Infinity,Mathf.Infinity)==null){
        _position=Camera.main.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(R1,R2,10));
        Instantiate(Resources.Load("Square",typeof (GameObject)),_position,Quaternion.identity);
        }
        else{
            Debug.Log("avoided collision");
        }
