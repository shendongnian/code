    /*Make sure you have Using "System.Collections.Generic" at the top */
    //put this outside function so that the inspector can see it
    public List<Transform> Objs;
    // in your function put this (when changing the color)
    foreach(Transform Tform in Objs){
      Tform.GetComponent<Renderer>().material.color = Color.red;
    }
