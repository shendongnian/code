    public class RenderableThing : IMakeANoise, IDoAThousandOtherThings
    {
        protected virtual string MyNoiseToMake { get { return ""; } }
    
        public virtual void MakeANoise()
        {
             Console.WriteLine(MyNoiseToMake);
        }
    }
    
    public class Dog : RenderableThing, IDog
    {
        protected override string MyNoiseToMake { get { return "Woof!"; } }
     
        public void Bark() { MakeANoise(); } // see what we did there?
        // Notice that I am not declaring the method MakeANoise because it is inherited and I am using it by overriding MyNoiseToMake
        
        public int NumberOfDogLegs { get { return 2; } }
        
        public int NumberOfDogFriends { get; set; } // this can be set
    
        private string SecretsOfDog { get; set; } // this is private   
    }
    public class DoorBell : RenderableThing, IDoorBell
    {
        public void Chime() { Console.WriteLine("Ding!"); }
        public override void MakeANoise()
        {
             Chime(); Chime(); Chime(); //I'll do it my own way!
        }
    }
