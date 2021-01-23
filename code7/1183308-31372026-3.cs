    //sealed in C# is the same as final in AS3
    public sealed class MyController
    {
        private float minBet = 0;
    
        public float minimumBet
        {
            get { return minBet; }
        }
    }
---------
    instanceOfMyController.minBet //will throw an error
    instanceOfMyController.minimumBet = 10; //will throw an error
    instanceOfMyController.minimumBet //will supply the value of the minBet var
