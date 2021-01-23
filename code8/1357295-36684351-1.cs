    using UnityEngine;
    using System.Collections;
    using UnityEngine.UI;
    
    public class PauseManager : MonoBehaviour {
    
        public GameObject pauseMenu;
    
        bool paused = false;
    
        void Start()
        {
            pauseMenu.SetActive(false);
        }
    
        void Update()
        {
            if(Input.GetButtonDown("escape"))
            {
                paused = !paused;
            }
            if (paused)
            {
				PauseGame();
    
            }
            if (!paused)
            {
				ResumeGame();
            }
    
        }
        void PauseGame(){
		    pauseMenu.SetActive(true);
            Time.timeScale = 0f;
		
		}
		
		void ResumeGame(){
		    pauseMenu.SetActive(false);
            Time.timeScale = 1f;
		
		}
        public void Resume()
        {
            ResumeGame();
        }
        public void pauseButton()
        {
            PauseGame();
        }
    }
