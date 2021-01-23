    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    using UnityEngine.SceneManagement;
    
    public class GameScript : MonoBehaviour {
    
        public Text text;
    
        // Update is called once per frame
        void Update()
        {
            //Check if up key is pressed
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                //Call the Game() function because up key was pressed
                Game();
            }
        }
    
        void Game()
        {
            //text.text = "Is your number " + compGuess + "?\n\n Press Up Arrow for higher, Down Arrow for lower and Space for equal to.";
            Debug.Log("Up Key Pressed!...Re-Loading Level");
    
            //Get name of current scene
            string currentSceneName = SceneManager.GetActiveScene().name;
    
            //Load current Scene again
            SceneManager.LoadScene(currentSceneName);
    
        }
    }
