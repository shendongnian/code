    void PopulatePanel(IEnumerable<Dog> dogs){
        foreach (Dog dog in dogs){
            // Unity requires that the object is stored in a local reference
            // Otherwise, all buttons will link to last item
            Dog tempDog = dog;
            GameObject button = (GameObject) Instantiate(buttonPrefab);
            // Name button with dog name
            button.name = tempDog.Name;   
            // Get the Button component on the new button object
            Button btn = button.GetComponent<Button>();  
            // On press of that newly created button, call the following method
            btn.onClick.AddListener(()=> 
            { Debug.Log(tempDog.Name+ " "+ tempDog.Race); });
            //Different way passing a dog instance
            btn.onClick.AddListener(()=> { UseDog(tempDog); });
        }
    }
    void UseDog(Dog dog){
        // Do stuff with dog object
    }
