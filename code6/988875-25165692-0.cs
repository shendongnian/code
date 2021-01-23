    catch (XmlException e)
    {
        string message = "ERROR: Schema " + e.Message;
        message = message.Replace(Environment.NewLine, "");
        
        Console.WriteLine(message);
        return false;
    }
