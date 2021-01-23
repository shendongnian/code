    ProjectileTracker tracker = GameObject.FindGameObjectWithTag("Projectile").GetComponent<ProjectileTracker>();
    //If the spacebar is pressed
    if (Input.GetKeyDown (KeyCode.Space) && tracker.ProjectileCount > 0) 
    {
        //Instatiate a new projectile prefab 2 units above the Player sprite
        Instantiate (Projectile, transform.position + transform.up * 2, Quaternion.identity);
        //Find the game object with the tag "Projectile" and call the     DecreaseProjectileCount() function from the ProjectileTracker script
        tracker.ProjectileCount--;
    }
...
    using UnityEngine;
    using System.Collections;
    public class ProjectileTracker : MonoBehaviour {
		//Variable to store the current projectile count
		public GameObject ProjectileRef;
		//Set the current projectile count to be 8
		private int projectileCount = 8;
		
		public int ProjectileCount
		{
			get { return projectileCount; }
			set { SetProjectileCount(value); }
		}
		//Function to decrease the current projectile count
		public void SetProjectileCount(int value)
		{
			projectileCount = value;
			//Print out the current projectile count
			ProjectileRef.GetComponent<TextMesh> ().text = value.ToString();
		}
    }
