    using System.Random rand;
        
        void Start()
        {
        rand = new System.Random();
        }
        
        public IEnumerator SpawnAtRandTime()
        {
          while(true)
         {        
           yield return new WaitForSeconds(rand.Next(0,100));
           SpawnEnemy();
         }
        }
