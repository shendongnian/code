    List<string> textFromMyInputs = new List<string>();
     void GetAllTextFromInputFields()
        {
        
        foreach(InputField inputField in gameObject.GetComponentsInChildren<InputField>())
        {
            foreach (Text text in inputField.GetComponentsInChildren<Text>())
            {
                if (text.gameObject.name != "Placeholder")
                    textFromMyInputs.Add(text.text);
            }
        }
        foreach (string s in textFromMyInputs)
        {
            Debug.Log(s);
        }
    }
