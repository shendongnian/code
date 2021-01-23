        public static List<GameObject> models;
        public static List<GameObject> selectedModels = new List<GameObject>();
        public static GameObject currentPoint;
        int index;
        public static string randomName;
        public AudioSource FindTheNumber;
        public static Random random = new Random();
        public void PlayNumbers()
        {   
            models = GameObject.FindGameObjectsWithTag("numbers").Except(selectedModels).ToList();
        
            if ((models == null) || (!models.Any()))
            {
                Console.WriteLine("No new game objects");
            }
            else
            {
                index = random.Next(models.Count);
                currentPoint = models[index];
                randomName = currentPoint.name;
                print ("Trackable " + randomName);
                FindTheNumber.Play ();
                currentPoint.GetComponent<AudioSource> ().PlayDelayed(2);
                selectedModels.Add(currentPoint);
            }
    }
