     class Program
    {
        static void Main(string[] args)
        {
            using (Vector3 position = new Vector3())
            {
                //In some loop
               consumePositionAsForce(position);
            }
        }
    }
    struct Vector3 : IDisposable
    {
        //Whatever you want to do here
    }
