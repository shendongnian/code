    public class DogSerializer : ISerializer<Dog>
    {
        public void Write(Dog obj, string data)
        {
            //Parse the data string and set properties on the object
        }
        public string Read(Dog obj)
        {
            //Create a string by reading properties from the dog object
        }
    }
