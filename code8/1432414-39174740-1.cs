    public class UserDataSerializationProvider : IBsonSerializationProvider
    {
        public IBsonSerializer GetSerializer(Type type)
        {
            if (type == typeof(UserData)) return new UserDataSerializer();
            return null;
        }
    }
