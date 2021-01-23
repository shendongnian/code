    private void InitializeLabels()
    {
       for (int i = 0; i < numberOfDice; i++)
       {
           string dieName = String.Format("die{0}", i + 1);
           dice[i].Text = new Label{Parent = this, 
                                    Text = dieName, 
                                    Size = new Size(50,20), 
                                    Location = new Point(i * 50, 0)};
       }
    }
