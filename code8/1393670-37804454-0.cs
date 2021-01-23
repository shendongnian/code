    using (var s = new StreamReader(filePath))
    {
        using (var jr = new JsonTextReader(s))
        {
            var js = new JsonSerializer();
            var obj = js.Deserialize<MyObject>(jr);
            return obj;
        }
    }
