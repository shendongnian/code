    catch (XmlException e)
    {
        string message = "ERROR: Schema " + e.Message;
        message = message.Replace(Environment.NewLine, "");
        message = message.Replace("\n", "");
        message = message.Replace("\r", "");
        
        Console.WriteLine(message);
        return false;
    }
