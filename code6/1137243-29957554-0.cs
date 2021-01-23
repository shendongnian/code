    public class Shirt : Clothing
    {
        public void ReNameShirt()
        {
    //        Shirt Po = new Shirt(); You are a shirt, there is no need to create one.
            name = "blue shirt";
    //        return ReNameShirt(); This will cause infinite recursion and crash.
        }
