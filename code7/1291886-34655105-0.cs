    using UnityEngine;
    using System.Collections;
    public class SetActiveOnTriggerEnter : MonoBehaviour {
        //public string FindGameOBJ; <-To be implemented for future re-usability. Ignore it for now.
        // public string ComponentToActivate; <-To be implemented for future re-usability. Ignore it for now.
        void OnTriggerEnter (Collider coll) // Collision detection.
        {
            if (coll.tag == "Ball") //Checks the tag to see if it is the PARENT OBJECT.
            {
                    if (!transform.FindChild("BallHealZone").gameObject.activeInHierarchy) //This is better form for looking , but there is a one better way, GetChild. You can see it on below. 
                    {
                        Debug.Log("Activating BallHealZone! :)"); //Tells me if it found said object, and confirms it is indeed null (yes it works).
                        transform.FindChild("BallHealZone").gameObject.SetActive(true); //Activates the CHILD OF PARENT OBJECT.
                        //or if you know index of child in parent you can use GetChild method for a faster one
                        transform.GetChild(indexOfChild).gameObject.SetActive(true); // this also activates child, but this is faster than FindChild method
                    }
            }
        }
    }
