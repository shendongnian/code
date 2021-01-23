    using UnityEngine;
    using System.Collections;
    
    public class ALITEST: MonoBehaviour
    {
        //Reference to the GameObject you want to Disable/Enable
        //Drag the Object you want to disable here(From the Editor)
        public GameObject gameObjectToDisable;
    
        void Start()
        {
    
        }
    
        void Update()
        {
            //Keep checking if mouse is pressed
            checkMouseClick();
        }
    
        //Code that checks when the mouse is pressed down(Replaces OnMouseDown function)
        void checkMouseClick()
        {
            //Check if mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo = new RaycastHit();
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
                {
                    //Check if the object clicked is that object
                    if (hitInfo.collider.gameObject == gameObjectToDisable)
                    {
                        Debug.Log("Cube hit");
                        StartCoroutine(wait()); //Call the function to Enable/Disable stuff
                    }
                }
            }
        }
    
        //This value is used to make sure that the coroutine is not called again while is it already running(fixes many bugs too)
        private bool isRunning = false;
    
        IEnumerator wait(float secondsToWait = 3)
        {
            //Exit coroutine while it is already running
            if (isRunning)
            {
                yield break; //Exit
            }
            isRunning = true;
    
            //Exit coroutine if gameObjectToDisable is not assigned/null
            if (gameObjectToDisable == null)
            {
                Debug.Log("GAME OBJECT NOT ATTACHED");
                isRunning = false;
                yield break; //Exit
            }
            gameObjectToDisable.SetActive(false);
    
            //Wait for x amount of Seconds
            yield return new WaitForSeconds(secondsToWait);
    
            //Exit coroutine if gameObjectToDisable is not assigned/null
            if (gameObjectToDisable == null)
            {
                Debug.Log("GAME OBJECT NOT ATTACHED");
                isRunning = false;
                yield break; //Exit
            }
            gameObjectToDisable.SetActive(true);
            isRunning = false;
        }
    }
