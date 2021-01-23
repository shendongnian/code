    void Update()
    {
     if (NKCell.GetComponent<ModelChangeScript>().HighqualityModel == true )
        {
            HQModelSpawn();
    NKCell.GetComponent<ModelChangeScript>().HighqualityModel = false;
         }
    
    
    public void HQModelSpawn()
    {
        HighQualityModel = false;
    
        Transform[] HQTransforms = this.GetComponentsInChildren<Transform>();
    
    
    
        foreach (Transform t in HQTransforms)
        {
            if (t.gameObject.CompareTag("HighQualityModel"))
    
            {
                HQMesh = t.gameObject;
    
    
                Instantiate(t.gameObject, CurrentPosition, Currentrotation);
    
    
    
    
                transform.position = CurrentPosition;
                transform.rotation = Currentrotation;
    
    
    
                Debug.Log("Found " + t);
    
                break;
            }
    
        }
    
    
    }
