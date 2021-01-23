     public int CompareTo(clsProcess other)
    {
     switch ((modGlobals.SortColumn))
        { 
            case modGlobals.SortType.Arr:
                return this.ArrTime.CompareTo(other.ArrTime);
            case modGlobals.SortType.Exe:
                return this.ExeTime.CompareTo(other.ExeTime);
            case modGlobals.SortType.Label:
                return this.Label.CompareTo(other.Label);
            case modGlobals.SortType.Prior:
                return this.Priority.CompareTo(other.Priority);
        }
        //This next part will happen if the switch statement doesnt find a match
        //use this to return some default value or a value that tells you it didnt find something
        //I'll use 0 as an example
        return 0;
        //now all paths return a value, even if it doesnt find a match in the switch statement
    }
