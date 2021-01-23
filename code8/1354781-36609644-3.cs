    public static void F()
    {
      ActionHelperOne helper = new ActionHelper();
      helper.randOne = new Random();
      helper.randTwo = new Random();
      Action a1 = helper.DoActionOne;
      Action a2 = helper.DoActionTwo;
    }
    
    private static void G(Random r)
    {
    }
    class ActionHelper
    {
        public Random randOne;
        public Random randTwo;
        public void DoActionOne()
        {
             G(randOne.Next());
        }
        public void DoActionTwo()
        {
             G(randTwo.Next() + randOne.Next());
        }
    }
