    private void InitializeLabels()
    {
       for (int i = 0; i < numberOfDice; i++)
       {
           string dieName = String.Format("die{0}", i + 1);
           dice[i].Text = dieName;
       }
    }
