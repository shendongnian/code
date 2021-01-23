     public GameObject gameTextObject; // Set this object on gameScreen for use DragAndDrop
        
            void Start(){
    
              if( gameTextObject == null)
                {
                  // if you set gameTextObject  on gameScreen this object not be null 
                  gameTextObject = GameObject.Find("InputObjectName");
                }
    
             // GetObjectText
             string gObjectTextValue = gameTextObject.Text;
    
              // SetObjectText
              gameTextObject.GetCOmponent<Text>().text = "Any Text";       
            }
