    // New variable to hold prefab object
    public GameObject modelObjectPrefab;
    
    // ...
    // ...
    // ...
    void PopulateList()
    {
         try {
             foreach (var item in itemList)
             {
                 // Reference prefab variable instead of class type
                 GameObject newModel = Instantiate(modelObjectPrefab) as GameObject;
                 ModelObject myModelObject = newModel.GetComponent<ModelObject>();
                 myModelObject.Name.text = item.Name;
                 myModelObject.Description.text = item.IDescription;
                 myModelObject.icon.sprite = item.Icon;
                 myModelObject.button.onClick = item.selectObject;
                 newModel.transform.SetParent(contentPanel);
    
             }
    
         } catch (System.Exception ex) {
    
         }
    }
