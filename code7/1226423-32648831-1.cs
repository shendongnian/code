    if(!IsNameAvailable(name))
    {
        writer.WriteLine("That name is in use. Pick an other one");
        SetName(writer, client);
        return;
    }
