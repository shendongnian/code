    public class MammalBase
    {
        public void GetDetails() { return... }
    }
    public class YourClass
    {
        public static void displayAnimal<T>(ref T mammal) where T : MammalBase // this is the constraint
        {
            mammal.GetDetails();
        }
    }
