    public Script(string scriptName, [Optional] ICollection<Tuple<string, bool>> internalFunctions, [Optional] long randomIdentifier)
    {
        if (internalFunctions != null)
        {
            // do something that needs internalFunctions to have a value
        }
        if (randomIdentifier != 0)
        {
            // do something that needs randomIdentifier to have a valid value
        }
        else
        {
            // either a value wasn't passed, or the value 0 was passed...
            //   you can't be sure, so you might want to make this nullable
        }
    }
