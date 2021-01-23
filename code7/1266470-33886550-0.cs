    public class JsonNet
    {
        public static string jsonString = @"{ ""inner"" : { ""name"" : ""myname""}}";
        public static Test GetTest()
        {
            return JsonConvert.DeserializeObject<Test>(jsonString);
        }
    }
    public class Inner
    {
        public string Name { get; set; }
    }
    public class Test
    {
        public Inner Inner { get; set; }
        public string Name
        {
            get { return Inner.Name; }
            set { Inner.Name = value; }
        }
    }
