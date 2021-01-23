    public static IEnumerable<float> Serie()
    {
       float val = 0f;
       while (true)
       {
          val += 0.5;
          yield return val;
       }  
    }
