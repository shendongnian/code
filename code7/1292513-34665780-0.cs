    Vector3 origin = transform.position;
    float sphereRadius = 1.0f; // Change this as needed depending on tolerance you want
    Vector3 direction = transform.forward;
    RaycastHit hitInfo;
    float maxCastDist = 5.0f; // Change this as needed depending on how close the object must be for interaction
    if (Physics.SphereCast(origin, sphereRadius, direction, out hitInfo, maxCastDist)){
        // Logic for checking whether object hit is interactable, etc using hitInfo.
    }
