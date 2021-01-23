    class ObstaclePlacer : MonoBehaviour
    {
        public int obstaclesAmmount;
        public GameObject [] obstaclesArray;
        public List<GameObject> obstaclesList;
        public void Start ()
        {
            var random = new System.Random();
            //Get the desired size of your array.
            obstaclesAmmount = random.Next(0, 100);
            //Initialize an array with the size of your random number
            obstaclesArray = new GameObject [obstaclesAmmount];
            //Or use a list which allows your to dynamically add elements later.
            obstaclesList = new List<GameObject> ();
            GenerateObstacles ();
        }
        void GenerateObstacles ()
        {
            for (int i = 0; i < obstaclesAmmount; i++) {
                var gameObject = new GameObject();
                obstaclesArray[i] = gameObject;
                obstaclesList.Add(gameObject);
            }
        }
        void OnDestroy ()
        {
            foreach (GameObject item in obstaclesArray) {
                //Destroy (item);
                Console.WriteLine ("Destroy (item); in obstaclesArray");
            }
            foreach (GameObject item in obstaclesList) {
                //Destroy (item);
                Console.WriteLine ("Destroy (item); in obstaclesList");
            }
        }
    }
