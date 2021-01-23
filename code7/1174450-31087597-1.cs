    public int StepsForward(int channel)
    {
       int steps = 0;
       while (!IsValid(channel))
       {
          channel--;
          if (channel < 0)
          {
             channel = 450;
          }
          steps++;
       }
       return steps;
    }
    public int StepsBackward(int channel)
    {
       int steps = 0;
       while (!IsValid(channel))
       {
          channel++;
          if (channel > 450)
          {
             channel = 0;
          }
          steps++;
       }
       return steps;
    }
