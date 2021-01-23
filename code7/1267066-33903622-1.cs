           Declare a Public GameObject boxObj;//Don't forget to assign your box's prefab
             void OnCollisionEnter2D(Collision2D other){
                timeshit++;
                texter.text = "Score Fall : " + timeshit;
                Destroy(col.gameObject,0.1f); 
            //  if (col.gameObject.tag == "Player") {//add a tag to your box and check it before destroying a gameObject
            //  Destroy(col.gameObject,0.1f);
            //  }
         
             Instantiate(boxObj, new Vector3(x?F, y?, z?), Quaternion.identity);
             // x,y,z are your desired positions
        
            }
