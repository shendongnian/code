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
