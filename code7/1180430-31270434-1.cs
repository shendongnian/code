    void Start(){
        floor = LayerMask.GetMask ("Floor");
        Ray RAY = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit floorHit;
        if (Physics.Raycast (ray, out floorHit)) {
            Vector3 playerMouse = floorHit.point - transform.position;
            playerMouse.y = 0f;
            MoveTo (playerMouse.x, playerMouse.z);
        }
    }
