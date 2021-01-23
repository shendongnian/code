    if (Input.GetMouseButtonDown(0))
    {
        Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D rayHit = Physics2D.Raycast(ray, Vector2.zero);
        if (rayHit)
        {
            if (rayHit.collider.CompareTag("up"))
            {
    
            }
        }
    }
