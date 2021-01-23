    Vector2 touchDeltaPosition;
    [SerializeField] float speed = 1f;
    void Update() {
        for (var i = 0; i < Input.touchCount; i++) {
            if (Input.GetTouch(i).phase == TouchPhase.Moved) {
                // get new finger position
                touchDeltaPosition = Input.GetTouch(i).deltaPosition;
                // move scene object along y axis
                transform.Translate(0f, -touchDeltaPosition.y * speed, 0f);
            }
        }    
    }
