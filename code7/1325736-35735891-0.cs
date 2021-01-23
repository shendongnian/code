    public class Generator
    {
        public static T GetRandomObject<T>()
        {
            if(typeof(T).IsInterface)
                throw new Exception("Generator needs to be instanciated with an interface generic parameter");
            Random rnd = new Random();
           
            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.GetInterfaces().Contains(typeof(T))).ToList();
            int index = rnd.Next(types.Count);
            return (T)Activator.CreateInstance(types[index]);
        }
    }
