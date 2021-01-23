    void Start () {
            
        if (numEnemies < YourThreshholdForNumberOfEnemies)
        {
            GameObject newParent = GameObject.Find("1-background elements");
                
            for (int i = 0; i < numEnemies; i++)
            {
                Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
                GameObject octo = Instantiate(enemyPrefab, newPos, Quaternion.identity) as GameObject;
                    octo.transform.parent = newParent.transform;
            
                Vector3 newPos1 = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
                GameObject octo1 = Instantiate(enemyPrefab1, newPos, Quaternion.identity) as GameObject;
                    octo1.transform.parent = newParent.transform;
                }
            }
        }
