    public void checkAnswer(){
        try {
            Text answer = (input.GetComponent<Text>()) as Text;
        
            if (answer.text == "George Washington") {
                Debug.Log("True");
            }
        }catch (UnassignedReferenceException)
        {
            Debug.Log ("Wrong answer");
        }
    }
