    bool keepRunningWaves = false;
    IEnumerator startingRunningWaves(float second = 20)
    {
        if (keepRunningWaves)
        {
            yield break;
        }
    
        keepRunningWaves = true;
    
        while (keepRunningWaves)
        {
    
            float timer = 0;
    
            int randWave = Random.Range(1, 5);
            while (timer < second)
            {
                if (!keepRunningWaves)
                {
                    yield break;
                }
                if (randWave == 1)
                {
                    Debug.Log("Running Wave 1");
                    Wave1();
                }
                else if (randWave == 2)
                {
                    Debug.Log("Running Wave 2");
                    Wave2();
                }
                else if (randWave == 3)
                {
                    Debug.Log("Running Wave 3");
                    Wave3();
                }
                else if (randWave == 4)
                {
                    Debug.Log("Running Wave 4");
                    Wave4();
                }
    
                timer += Time.deltaTime;
                yield return null;
            }
            //Reset Timer for next run 
            timer = 0;
    
            yield return null;
        }
       keepRunningWaves = false;
    }
    
    void stopRunningWaves()
    {
        keepRunningWaves = false;
    }
