    static class Helper 
    {
        public static void ConcreteMethodB(Action caller)
        {
            //Huge code unrelated to this class
            caller();
        }
    }
