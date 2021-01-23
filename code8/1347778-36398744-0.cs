    /// FOR textures10x6
        public List<int> newRandtextures10x6List = new List<int>();
        private void newRandtextures10x6Func(int arrayAmount)
        {
            System.Random a = new System.Random();
            int MyNumber = 0;
    
            //Reset
            newRandtextures10x6List.Clear();
    
            //2 seconds Timer. If it blocks exit 2 seconds exit
            System.DateTime startTime = System.DateTime.UtcNow;
            System.TimeSpan exitTime = System.TimeSpan.FromSeconds(2);
    
            bool quitRand = false;
    
            for (int i = 0; i < arrayAmount; i++)
            {
                do
                {
                    if (System.DateTime.UtcNow - startTime > exitTime)
                    {
                        quitRand = true;
                        Debug.Log("Time out Reached! ...Assigning 0 to it");
                        newRandtextures10x6List.Add(0);
                        break;
                    }
                    MyNumber = a.Next(0, arrayAmount);
                } while (newRandtextures10x6List.Contains(MyNumber));
                newRandtextures10x6List.Add(MyNumber);
    
                /* OPTIONAL. WILL QUIT THE WHOLE FUNCTION INSTEAD OF JUST THE WHILE LOOP
                if (quitRand)
                {
                    break;
                }*/
            }
        }
    
        /// FOR topBottomtextures
        public List<int> newRandTopBottomtexturesList = new List<int>();
        private void newRandTopBottomtexturesFunc(int arrayAmount)
        {
            System.Random a = new System.Random();
            int MyNumber = 0;
    
            //Reset
            newRandTopBottomtexturesList.Clear();
    
            //2 seconds Timer. If it blocks exit 2 seconds exit
            System.DateTime startTime = System.DateTime.UtcNow;
            System.TimeSpan exitTime = System.TimeSpan.FromSeconds(2);
    
            bool quitRand = false;
    
            for (int i = 0; i < arrayAmount; i++)
            {
                do
                {
                    if (System.DateTime.UtcNow - startTime > exitTime)
                    {
                        quitRand = true;
                        Debug.Log("Time out Reached! ...Assigning 0 to it");
                        newRandTopBottomtexturesList.Add(0);
                        break;
                    }
                    MyNumber = a.Next(0, arrayAmount);
                } while (newRandTopBottomtexturesList.Contains(MyNumber));
                newRandTopBottomtexturesList.Add(MyNumber);
    
                /* OPTIONAL. WILL QUIT THE WHOLE FUNCTION INSTEAD OF JUST THE WHILE LOOP
                if (quitRand)
                {
                    break;
                }*/
            }
        }
