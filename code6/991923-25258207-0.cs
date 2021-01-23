    public IEnumerable GetPowersofTwo()
    {
       for (int i = 1; i < 10; i++)
           yield return (int)System.Math.Pow(2, i);
       yield break;
    }
