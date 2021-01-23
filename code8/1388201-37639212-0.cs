    private RaycastHit hit;
    void Update(){
        Physics.Raycast (Camera.main.ScreenPointToRay (Input.mousePosition), out hit);
            if (Input.GetMouseButtonDown(1) && hit.collider){
               hit.collider.gameObject.renderer.material.color = Color.red;
            }
    }
