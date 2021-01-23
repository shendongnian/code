    public Plane groundPlane;
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 point = GetIntersectionPoint(groundPlane, ray)
            Debug.Log(point.ToString());
        }
    }
    Vector3 GetIntersectionPoint(Plane plane, Ray ray) {
        float rayDistance;
        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);
        }  
    }
