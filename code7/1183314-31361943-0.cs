        object word;
        try
        {
            word = System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
    //If there is a running Word instance, it gets saved into the word variable
        }
        catch (COMException)
        {
    //If there is no running instance, it creates a new one
            Type type = Type.GetTypeFromProgID("Word.Application");
            word = System.Activator.CreateInstance(type);
        }
