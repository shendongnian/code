    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10; // distance from the camera
            target = Camera.main.ScreenToWorldPoint(mousePosition);
            target.z = transform.position.z;
        }
        if (Input.touchCount > 0)
        {
            target.x = Input.touches[0].deltaPosition.x;
            target.y = Input.touches[0].deltaPosition.y;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
    void FixedUpdate()
    {
        float LastInputX = transform.position.x - target.x;
        float LastInputY = transform.position.y - target.y;
        if (LastInputX != 0 || LastInputY != 0)
        {
            anim.SetBool("walking", true);
            if (LastInputX > 0)
            {
                anim.SetFloat("LastMoveX", 1f);
            }
            else if (LastInputX < 0)
            {
                anim.SetFloat("LastMoveX", -1f);
            }
            else {
                anim.SetBool("walking", false);
            }
            if (LastInputY > 0)
            {
                anim.SetFloat("LastMoveY", 1f);
            }
            else if (LastInputY < 0)
            {
                anim.SetFloat("LastMoveY", -1f);
            }
            else {
                anim.SetFloat("LastMoveY", 0f);
            }
        }
        else {
            anim.SetBool("walking", false);
        }
    }
