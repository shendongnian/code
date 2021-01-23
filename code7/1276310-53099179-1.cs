        //Create User object.  
        User user = new User("Bob", 42);  
        //Create a stream to serialize the object to.  
        MemoryStream ms = new MemoryStream();  
        // Serializer the User object to the stream.  
        DataContractJsonSerializer ser = new 
        DataContractJsonSerializer(typeof(User));  
        ser.WriteObject(ms, user);  
        byte[] json = ms.ToArray();  
        ms.Close();  
        return Encoding.UTF8.GetString(json, 0, json.Length);  
    }  
    // Deserialize a JSON stream to a User object.  
    public static User ReadToObject(string json)  
    {  
        User deserializedUser = new User();  
        MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));  
        DataContractJsonSerializer ser = new 
        DataContractJsonSerializer(deserializedUser.GetType());  
        deserializedUser = ser.ReadObject(ms) as User;  
        ms.Close();  
        return deserializedUser;  
    }
