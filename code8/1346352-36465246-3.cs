    //Outside function
    public GameObject[] Objs;
    //inside function
    Objs = GameObject.FindGameObjectsWithTag("ATagToChangeColor");
    foreach(Transform Tform in Objs){
      Tform.GetComponent<Renderer>().material.color = Color.red();
    }
