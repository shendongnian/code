        float validInputThresold = 5f;
    enum Gestures {
        None,
        Stationary,
        SwipeRight,
        SwipeLeft,
        SwipeUp,
        SwipeDown
    }
    Gestures currentGesture;
    public void Update() {
        currentGesture = Gestures.None;
        HandleTouch(Input.GetTouch(0));
        HandleCharacterMovement(currentGesture);
    }
    Vector3 originalPosition;
    void HandleTouch(Touch touch) {
        if (touch == null) return;
        
        switch (touch.phase) {
            case TouchPhase.Began:
                originalPosition = touch.position;
                break;
            case TouchPhase.Moved:
                Vector3 delta = touch.position - originalPosition;
                if (delta.magnitude > validInputThresold) Moved(touch, delta);
                break;
            case TouchPhase.Stationary:
                currentGesture = Gestures.Stationary;
                break;
            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                currentGesture = Gestures.None;
                break;
        }
    }
    public float gestureThresold = 10f;
    void Moved(Touch touch, Vector3 delta) {
        if ((Mathf.Abs(delta.x)<=gestureThresold && Mathf.Abs(delta.y)<=gestureThresold)
            || (Mathf.Abs(delta.x)>gestureThresold && Mathf.Abs(delta.y)>gestureThresold) )
                currentGesture = Gestures.Stationary; //IF FINGER MOVED IN DIAGONAL, INVALID STATE FALLSBACK TO STATIONARY
        else if (delta.x > gestureThresold) currentGesture = Gestures.SwipeRight;
        else if (delta.x < -gestureThresold) currentGesture = Gestures.SwipeLeft;
        else if (delta.y > gestureThresold) currentGesture = Gestures.SwipeUp;
        else if (delta.y < -gestureThresold) currentGesture = Gestures.SwipeDown;
    }
    bool playerIsMoving = false;
    // ALL THE ROUTINES HERE SET THE PLAYER IS MOVING FLAG
    // TO TRUE AND THEN TO FALSE WHEN THE MOVEMENT IS DONE
    void HandleCharacterMovement(Gestures gesture) {
        if (playerIsMoving) return;
        switch (gesture) {
            default:
            case Gestures.None:
            case Gestures.Stationary:
                return;
            case Gestures.SwipeRight:
                StartCoroutine(MovePlayerRight());
                return;
            case Gestures.SwipeLeft:
                StartCoroutine(MovePlayerLeft());
                return;
            case Gestures.SwipeUp:
                StartCoroutine(Jump());
                return;
            case Gestures.SwipeDown:
                StartCoroutine(Crouch());
                return;
        }
    }
