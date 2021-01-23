    GameManagerThingy {
        public int ReqEntries {get;set;}
        private string curSelectedString = "";
        private image[] selectedImages;
        public void AddNumber(string numVal, image img) {
            //Insert image and display it on keypad
            //curSelectedString += numVal
            if (ReqEntries == curSelectedString.length-1) 
                //This means enough buttons have been pressed and whatever
                //Evaluation logic you have for entering correct #'s is here
            else
                //The game would continue
        }
    }
    ButtonClickScript {
         public image buttonImage {get;set;}
         public string buttonValue {get;set;}
         //Tie an onclick event to your game object for when it is clicked
         public void OnClickFunction() {
             GameObject.FindWithTag("manager").GetComponent<SomeScript>().AddNumber(buttonValue, buttonImage);
         }
    }
