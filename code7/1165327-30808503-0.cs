    using UnityEngine;
    using System.Collections;
    
    public class FormationController : MonoBehaviour {
        public GameObject enemyPrefab;
        public float widthToLeft = 5;
        public float widthToRight = 5;
        public float height = 5;
        public float speed = 5;
        public float padding = 1.5f;
        public float SpawnDelaySeconds = 1;
        private int direction = 1;
        private float boundaryLeftEdge,boundaryRightEdge;
        private PlayerController playerController;
        // Use this for initialization
    
        void Start () {
            float distance = transform.position.z - Camera.main.transform.position.z;
            Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
            Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
            boundaryLeftEdge = leftmost.x + padding;
            boundaryRightEdge = rightmost.x - padding;
            SpawnUntilFull();
        }
    
    
    
        void OnDrawGizmos () {
            Gizmos.DrawWireCube(transform.position, new Vector3 (widthToLeft+widthToRight, height));
        }
    
        // Update is called once per frame
        void Update () {
            float formationRightEdge = transform.position.x + 0.5f * widthToRight;
            float formationLeftEdge = transform.position.x - 0.5f * widthToLeft;
            if (formationRightEdge > boundaryRightEdge) {
                direction = -1;
            }
            if (formationLeftEdge < boundaryLeftEdge) {
                direction = 1;
            }
            transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
            if (AllEnemiesAreDead()) {
                SpawnUntilFull();
            }
        }
    
        void SpawnUntilFull () {
            Transform freePos = NextFreePosition();
            GameObject enemy = Instantiate(enemyPrefab, freePos.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = freePos;
            if (FreePositionExists()) {
                Invoke ("SpawnUntilFull", SpawnDelaySeconds);
            }
    
        }
    
        bool FreePositionExists () {
            foreach( Transform position in transform) {
                if (position.childCount <= 0) {
                    return true;
                }
            }
            return false;
        }
    
        Transform NextFreePosition() {
            foreach (Transform position in transform) {
                if (position.childCount <= 0) {
                    return position;
                }
            }
            return null;
        }
    
        bool AllEnemiesAreDead () {
            foreach(Transform position in transform) {
                if (position.childCount > 0) {
                return false;
                }           
            }
            return true;
        }
    }
