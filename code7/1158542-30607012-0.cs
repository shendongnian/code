    public class Quiz : MonoBehaviour {
    
        public GameObject quizPanel;
        public GameObject input;
    
        public void checkAnswer(){
            try {
            Text answer = (input.GetComponent<Text>()) as Text;
    
            
                if (answer.text == "George Washington") {
                    Debug.Log("True");
                }
            }catch (UnassignedReferenceException ex)
            {
                Debug.Log ("Wrong answer");
                Log.Item(ex); 
    
            }
        }
    }
