    using UnityEngine;
    using System.Collections;
    public class Hero : MonoBehaviour {
        float speed = 2f;
        bool hero_up = false;
        bool hero_down = false;
        bool hero_left = false;
        bool hero_right = false;
        public Animator animator;
        public Rigidbody2D rbEnemy;
    
        // Use this for initialization
        void Start () 
        {
            animator = GetComponent<Animator> ();
    
        // Invokes the method methodName in time seconds, then repeatedly every   repeatRate seconds.
        InvokeRepeating("EnemySpawn", 3, 3);
           
        }
    
        void EnemySpawn()
        {
            Rigidbody2D EnemyInstance;
            EnemyInstance = Instantiate(rbEnemy, new Vector3(Random.Range (2f, 8f), Random.Range (-4f, 4f) ,0f), Quaternion.Euler(new Vector3(0f,0f,0f))) as Rigidbody2D;
    
        }
    }
