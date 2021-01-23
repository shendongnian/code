    public GameObject target = null;
    void Update () 
    {
       if(Input.touchCount > 0 || Input.GetTouch(0).phase == TouchPhase.Began)
       {
           Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
           Debug.DrawRay(ray.origin,ray.direction * 20,Color.red);
           RaycastHit hit;
           if(Physics.Raycast(ray, out hit,Mathf.Infinity))
           {
                Debug.Log(hit.transform.gameObject.name);
                if(this.target != null){
                    SelectMove sm = this.target.GetComponent<SelectMove>()
                    if(sm != null){ sm.enabled = false; }
                }
                target = hit.transform.gameObject; 
                //Destroy(hit.transform.gameObject);
                selectedPlayer();
           }
        }
     }
    
     void selectedPlayer(){
        SelectMove sm = this.target.GetComponent<SelectMove>();
           if(sm == null){
               target.AddComponent<SelectMove>();
           }
           sm.enabled = true;  
     }
