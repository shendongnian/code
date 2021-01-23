    } else if (Input.GetMouseButton (0) == true) {
        ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        if (Physics.Raycast (ray, out hit)) {
            print (hit.collider.gameObject.name);
            // If this is the clicked object
            if(hit.collider.gameObject == gameObject){
                Vector3 mousePosition = Input.mousePosition;
                Rigidbody rigidbody = GetComponent<Rigidbody> ();
                if (lastMousePosition.y > mousePosition.y){
                    rigidbody.AddForce (0, -Input.mousePosition.y, 0);
                }else if (lastMousePosition.y == mousePosition.y){
                    rigidbody.AddForce (0, 0, 0);
                }else{
                    rigidbody.AddForce (0, Input.mousePosition.y, 0);
                }
            }
            lastMousePosition = mousePosition;
        }
    } else if ...
