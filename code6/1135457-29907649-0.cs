    abstract class Challenge 
    {
      private Challenge() {} 
      private class ChallengeA : Challenge 
      {
        public ChallengeA() { ... }
      }
      private class ChallengeB : Challenge 
      {
        public ChallengeB() { ... }
      }
      public static Challenge MakeA() 
      {
        return new ChallengeA();
      }
      public static Challenge MakeB() 
      {
        return new ChallengeB();
      }
    }
