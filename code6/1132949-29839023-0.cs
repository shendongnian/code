    using UnityEngine;
    using System.Collections;
    public class Spawner : MonoBehaviour {
        public bool SpawnerEnabled;
        public GameObject Enemy;
        public float SpawnInterval;
        private Float timer;
        void Start () 
        {
            SpawnerEnabled = true;
            StartCoroutine (SpawnEnemy ());
        }
    
        IEnumerator SpawnEnemy()
        {
            while (SpawnerEnabled) {
                timer +=Time.deltaTime();
                if(timer >= SpawnInterval){
                  GameObject alien = Instantiate(Enemy) as GameObject;
                  alien.name = "Enemy";
                  alien.transform.position = new Vector3(-20,Random.Range(-4f,5f), 2);
    
                  yield return new WaitForSeconds(SpawnInterval);
                  timer = 0;
                  SpawnInterval += Mathf.Sqrt(time);
                }
        }
    }
