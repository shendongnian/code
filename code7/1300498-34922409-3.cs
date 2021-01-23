    using static SharedLibrary.SharedLibraryClassOne;
    using static SharedLibrary.SharedLibraryClassTwo;
    
    namespace StackOverflowChallenge20160121
    {
        class Program
        {
            static void Main(string[] args)
            {
                PotentialCollisionMethod(); // Invokes SharedLibraryClassOne.PotentialCollisionMethod
                SharedLibraryMethodThree();
            }
        }
    }
