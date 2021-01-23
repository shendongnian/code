    string content;
    using (var reader = new StreamReader(filename))
    {
        content = reader.ReadToEnd();
    }
    content += "x,y,z";
    using (var writer = new StreamWriter(filename))
    {
        writer.Write(content);
    }
