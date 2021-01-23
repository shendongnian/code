    // Receieve class inherits Dictionary. Use <string, object> if your values  
    // are of different types
    class Receive : Dictionary<string, int> {}
 
    class Mover
    {
       private Receive bodypart;
       // assigns value to bodypart field
       public Mover(Receive bodypart)
       {
           this.bodypart = bodypart;
       }
       // get element from bodypart using string argument
       public int GetBodyPart(string name)
       {
           return bodypart[name];
       }
    }
    class Class26
    {
        static void Main()
        {
            // instantiates collection
            Receive res = new Receive();
            // add elements to collection
            res.Add("head", 5);
            // instantiates Mover and pass collection as parameter to ctor
            Mover m = new Mover(res);
            // takes one element from collection
            int a = m.GetBodyPart("head");
            Console.WriteLine(a);
        }
    }
