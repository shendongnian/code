    public float mouseDistance;
    public Vector2 mouseDown = -Vector2.one;
    public float normalizedSpeed;
    public void Update()
    {
       if(Input.GetMouseButtonDown(0))
          mouseDown = Input.MousePosition();
       if(Input.GetMouseButtonUp(0))
          mouseDown = -Vector2.one;
       if(Input.GetMouseButton(0))
          normalizedSpeed = mouseDown != -Vector2.one ?
          Mathf.Clamp((mouseDown - Input.MousePosition()).sqrMagnitude, 0, (mouseDistance * mouseDistance)) / (mouseDistance * mouseDistance)
          : 0;
    }
