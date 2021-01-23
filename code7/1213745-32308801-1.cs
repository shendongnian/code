    private void Update()
    {
        if (Input.touchCount != 1) return;
        
        var wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        var touchPos = new Vector2(wp.x, wp.y);
    
        if (collider2D == Physics2D.OverlapPoint(touchPos))
        {
            // Your code
        }
    }
