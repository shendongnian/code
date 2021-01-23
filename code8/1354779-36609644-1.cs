    public static void F()
    {
      ActionHelperOne a1Helper = new ActionHelperOne();
      a1Helper.randOne = new Random();
      ActionHelperTwo a2Helper = new ActionHelperTwo();
      a2Helper.randTwo = new Random();
      Action a1 = a1Helper.DoActionOne;
      Action a2 = a2Helper.DoActionTwo;
    }
    
    private static void G(Random r)
    {
    }
    class ActionHelperOne
    {
        public Random randOne;
        public void DoActionOne()
        {
             G(randOne);
        }
    }
    class ActionHelperTwo
    {
        public Random randTwo;
        public void DoActionTwo()
        {
             G(randTwo);
        }
    }
