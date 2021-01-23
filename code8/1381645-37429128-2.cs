    public void GetLargeFire(GameObject[] gOBJ, int amountToReturn)
    {
        for (int i = 0; i < gOBJ.Length; i++)
        {
            if (i < amountToReturn)
            {
                gOBJ[i] = GetLargeFire();
            }
            else
            {
                //Fill the rest with null to override what was inside of it previously
                gOBJ[i] = null;
            }
        }
    }
