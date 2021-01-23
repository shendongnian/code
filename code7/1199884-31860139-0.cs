    ProjectileTracker tracker = GameObject.FindGameObjectWithTag("Projectile").GetComponent<ProjectileTracker>();
    //If the spacebar is pressed
    if (Input.GetKeyDown (KeyCode.Space) && tracker.HasProjectiles) 
    {
        //Instatiate a new projectile prefab 2 units above the Player sprite
        Instantiate (Projectile, transform.position + transform.up * 2, Quaternion.identity);
        //Find the game object with the tag "Projectile" and call the     DecreaseProjectileCount() function from the ProjectileTracker script
        tracker.DecreaseProjectileCount();
    }
...
    using UnityEngine;
    using System.Collections;
    public class ProjectileTracker : MonoBehaviour {
    //Variable to store the current projectile count
    public GameObject ProjectileRef;
    //Set the current projectile count to be 8
    int CurrentProjectileCount = 8;
    // Do i have any projectiles?
    public bool HasProjectiles {
    get { return CurrentProjectileCount > 0; } }
    //Function to decrease the current projectile count
    public void DecreaseProjectileCount()
    {
        //Decrease the current projectile count by 1
        CurrentProjectileCount--;
        //Print out the current projectile count
        ProjectileRef.GetComponent<TextMesh> ().text = CurrentProjecileCount.ToString ();
    }
    }
