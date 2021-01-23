    {
      int I;
      for (I = 0; I < 10; I++)
      {
        actions.Add(new Action(() => Print(I.ToString())));
      }
    }
