    using UnityEngine;
    using System.Collections;
    public class EnemySpawningScript : MonoBehaviour 
    {
        public GameObject spawnType = null;
        public float scaleMin = 0.5f;
        public float scaleMax = 2.0f;
        void Update ()
        {
            if (Input.GetKey (KeyCode.Space)) 
            {
                GameObject basicUnit = Instantiate(spawnType) as GameObject;
                basicUnit.transform.position = transform.position;
                float scaleOfEnemies = Random.Range (scaleMin, scaleMax);
                basicUnit.transform.localScale = Vector3.one * scaleOfEnemies;
                // the rigidbody should just be added to the prefab directly
                basicUnit.AddComponent<Rigidbody>();
                basicUnit.name = "ProtoTypeEnemies";
                // change color of this enemy
                Color rColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                basicUnit.GetComponent<Renderer>().material.color = rColor;
            }
        }
    }
