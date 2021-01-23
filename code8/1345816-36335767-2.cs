    public static void Serialize<Object>(Object dictionary, Stream stream)
    {
        try // try to serialize the collection to a file
        {
            using (stream)
            {
                // create BinaryFormatter
                BinaryFormatter bin = new BinaryFormatter();
                // serialize the collection to file (stream)
                bin.Serialize(stream, dictionary);
            }
        }
        catch (IOException)
        {
        }
    }
    public static Object Deserialize<Object>(Stream stream) where Object : new()
    {
        Object ret = CreateInstance<Object>();
        try
        {
            using (stream)
            {
                // create BinaryFormatter
                BinaryFormatter bin = new BinaryFormatter();
                // deserialize the collection from file (stream)
                ret = (Object)bin.Deserialize(stream);
            }
        }
        catch (IOException)
        {
        }
        return ret;
    }
    // function to create instance of T
    public static Object CreateInstance<Object>() where Object : new()
    {
        return (Object)Activator.CreateInstance(typeof(Object));
    }
