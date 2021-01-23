    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var thing = value as IThing;
        if (thing == null)
            throw new ArgumentException($"Writing Json failed because " + 
              "value was not a 'Thing' of type, {typeof(IThing).FullName}");
        JObject jsonThing;
        //If your solution is multithreaded,
        //and is using a shared serializer (which you probably are),
        //you should lock the serializer so that it doesn't accidentally use 
        //the "CustomObjectResolver"
        lock (serializer)
        {
            //Hold the original value(s) to reset later
            var originalContractResolver = serializer.ContractResolver;
            //Set custom value(s)
            serializer.ContractResolver = new CustomObjectResolver();
            //Serialization with custom properties
            jsonThing = JObject.FromObject(value, serializer);
            //Reset original value(s)
            serializer.ContractResolver = originalContractResolver;
        }
        //Finish serializing and write to writer.
    }
