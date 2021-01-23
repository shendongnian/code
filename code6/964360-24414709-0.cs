    public class Person
    {
        public String Name { get; set; }
        public static Person Load(Stream stream)
		{
			return new XmlSerializer(GetType()).Deserialize(stream) as Person;
		}
	}
