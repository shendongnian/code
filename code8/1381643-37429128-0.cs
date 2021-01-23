    public void GetLargeFireArray(GameObject[] gOBJ, int amountToReturn)
    {
        for (int i = 0; i < gOBJ.Length; i++)
        {
            if (i < amountToReturn)
            {
                Debug.Log("me " + i);
                gOBJ[i] = GetLargeFire();
            }
            else
            {
                //Fill the rest with null to override what was inside of it previously
                gOBJ[i] = null;
            }
        }
    }
