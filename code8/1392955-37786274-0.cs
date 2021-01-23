     void Update()
        {
    
            if (Input.GetMouseButtonDown(0))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject.tag == "Test")
                    {
                        Debug.Log("Wall Clcked");
                    }
                }
    
            }
            if (Input.GetMouseButtonDown(1))
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    hit.collider.gameObject.GetComponent<Renderer>().material.color = Color.red;
                }
    
            }
        }
