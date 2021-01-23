    GameObject target;
    // or
    Transform target;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                target = hit.transform.gameObject;
                // or
                target = hit.transform;
            }
        }   
    }
