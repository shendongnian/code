    Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
    float rayLength = 500f;
    // actual Ray
    Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
    // debug Ray
    Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);
    
    RaycastHit hit;
    if (Physics.Raycast(ray, out hit, rayLength))
    {
        // our Ray intersected a collider
    }
