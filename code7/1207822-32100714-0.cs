    interface ICanProcess
    {
        bool Process();
    }
    class JSONUser : ICanProcess
    {
        // implement Process for this object
    }
    static bool GetJSON<T>()
        where T: ICanProcess
    {
        ...
        bool result = true;
        foreach(T it in oJSON)
        {
            // I assume the result should be AND of all items process result
            result = result && it.Process();  
        }
    }
