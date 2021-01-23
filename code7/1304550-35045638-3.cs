    void Update () {
        for (var i = 0; i < Input.touchCount; ++i) {
            if (Input.GetTouch(i).phase == TouchPhase.Began) {
                Destroy (gameObject);
            }
        }
    }
