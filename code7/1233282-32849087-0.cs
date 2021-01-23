    using UnityEngine;
    using UnityEngine.EventSystems;
    
    public class JumpButton : MonoBehaviour {
    
        private bool shouldJump = false;
    
    	// Update is called once per frame
    	void Update () {
            //Find the player
            var player = GameObject.FindGameObjectWithTag("Player");
            //No player? exit out.
            if (player == null)
                return;
            //Is the jump button currently being pressed?
            if (shouldJump)
            {
                //Translate it upwards with time.
                player.transform.Translate(new Vector3(0, Time.deltaTime * 5, 0));
                //Make sure the Rigidbody is kinematic, or gravity will pull us down again
                if (player.GetComponent<Rigidbody>().isKinematic == false)
                    player.GetComponent<Rigidbody>().isKinematic = true;
            }
            //Not jumping anymore? reset the Rigidbody.
            else
                player.GetComponent<Rigidbody>().isKinematic = false;
        }
    
        //When the button is being pressed down, this function is called.
        public void ButtonPressedDown(BaseEventData e)
        {
            shouldJump = true;
        }
    
        //When the button is released again, this function is called.
        public void ButtonPressedUp(BaseEventData e)
        {
            shouldJump = false;
        }
    }
