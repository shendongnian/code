    Vector3 camAngles = viewCamera.transform.rotation.eulerAngles; 
    
    Debug.Log("cam angles .. " + camAngles.x.ToString("f4"));
    Debug.Log("cam angles .. " + camAngles.y.ToString("f4"));
    Debug.Log("cam angles .. " + camAngles.z.ToString("f4"));
    
    Vector3 newEulerAngles = camAngles;
    
    newEulerAngles.x = 0; 
    newEulerAngles.z = 0;
    
    Debug.Log("new angles .. " + newEulerAngles.x.ToString("f4"));
    Debug.Log("new angles .. " + newEulerAngles.y.ToString("f4"));
    Debug.Log("new angles .. " + newEulerAngles.z.ToString("f4"));
    
    character.transform.eulerAngles = newEulerAngles;
