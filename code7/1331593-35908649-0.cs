    void PopulatePanel(int size){
        for (int i = 0; i < size; i++){
            Dog dog = new Dog(GetName(), GetRace(),...); 
            GameObject button = (GameObject) Instantiate(buttonPrefab);
            Button btn = button.GetComponent<Button>();
            btn.onClick.AddListener(()=> 
            { Debug.Log(dog.Name+ " "+ dog.Race); });
            //Different way passing a dog instance
             btn.onClick.AddListener(()=> { UseDog(dog); }
        }
    }
    void UseDog(Dog dog){
        // Do stuff with dog object
    }
