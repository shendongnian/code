    bool shouldReadId = false;
    while (reader.Read())
    {
        if (reader.NodeType == XmlNodeType.Text && shouldReadId)
        {
            Console.WriteLine(reader.Value); // will print 39
            shouldReadId = false;
        }
        if (reader.Value.Equals("Id"))
        {
            // indicate that we should read the value of the next element
            // in the next iteration
            shouldReadId = true;
        }
    }
