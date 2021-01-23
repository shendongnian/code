    if (Input.GetMouseButtonDown(0))
    {
        Vector2 cubeRay = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D cubeHit = Physics2D.Raycast(cubeRay, Vector2.zero);
    
        if (cubeHit)
        {
            Debug.Log("We hit " + cubeHit.collider.name);
        }
    }
