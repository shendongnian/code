    void Update()
     {
         if (Input.touchCount == 1)
         {
             Vector3 wp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
             Vector2 touchPos = new Vector2(wp.x, wp.y);
             if (collider2D == Physics2D.OverlapPoint(touchPos))
             {
                 //your code
     
             }
         }
     }
