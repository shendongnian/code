    void Update() {
        for (var i = 0; i < Input.touchCount; i++) {
            if (Input.GetTouch(i).phase == TouchPhase.Began) {
                // assign new position to where finger was pressed
                transform.position = new Vector3 (transform.position.x, Input.GetTouch(i).position.y, transform.position.z);
            }
        }    
    }
