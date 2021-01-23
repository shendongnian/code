    using UnityEngine;
    using System.Collections;
    
    public class Spawn : MonoBehaviour 
    {
        public Vector3[] Positions;
        [SerializeField]
        GameObject ThingToSpawn;
        void Start () 
        {
            if (ThingToSpawn == null) 
            {
                Debug.LogError ("ThingToSpawn is null for instance of Spawn.cs at "+transform.name);
                return;
            }
            Instantiate (ThingToSpawn,Positions[Random.Range(0,3)],Quaternion.identity);
        }
    }
