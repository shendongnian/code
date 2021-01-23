    private void Update() {
        //User input (touches) will select cubes
        if(Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
        }
        Touch[] touches = Input.touches;
    
        foreach(var touchInput in touches) {
            float radius = 1.0f; // Change as needed based on testing
            Vector2 worldTouchPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            RaycastHit2D[] allHits = Physics2D.CircleCastAll(worldTouchPoint, radius, Vector2.zero);
    
            // Find closest collider that was hit
            float closestDist = Mathf.Infinity;
            GameObject closestObject = null;
            foreach (RaycastHit2D hit in allHits){
                // Record the object if it's the first one we check,
                // or is closer to the touch point than the previous
                if (closestObject == null ||
                    Vector2.Distance(closestObject.transform.position, worldTouchPoint) < closestDist){
                    closestObject = hit.collider.gameObject;
                    closestDist = Vector2.Distance(closestObject.transform.position, worldTouchPoint);
                }
            }
            
            // Finally, select the object we chose based on the criteria
            if (closestObject != null) {
                selectedCube = closestObject;
                selectedCube.GetComponent<SpriteRenderer>().color = Color32.Lerp(defaultColor, darkerColor, 1);
            }
        }
    }
