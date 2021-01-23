    public abstract class Word
    {
        public abstract string GetDescription();
        //....
    }
    
    public class Noun : Word
    {
        public override string GetDescription()
        {
            //Here you can access the Article property
            //...
        }
        //...
    }
