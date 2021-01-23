    private void Update() {
        //User input (touches) will select cubes
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
        }
        Touch[] touches = Input.touches;
    
        foreach(var touchInput in touches) {
            float radius = 1.0f; // Change as needed based on testing
            RaycastHit2D hit = Physics2D.CircleCast(Camera.main.ScreenToWorldPoint((Input.GetTouch(0).position)), radius, Vector2.zero);
    
            if (hit.collider != null) {
                selectedCube = hit.collider.gameObject;
                selectedCube.GetComponent<SpriteRenderer>().color = Color32.Lerp(defaultColor, darkerColor, 1);
            }
    
        }
    }
