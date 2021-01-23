    internal SafeMILHandleMemoryPressure(long gcPressure)
    {
        this._gcPressure = gcPressure;
        this._refCount = 0;
        if (this._gcPressure > 8192L)
        {
            MemoryPressure.Add(this._gcPressure);   // Kills UI interactivity !!!!!
            return;
        }
        GC.AddMemoryPressure(this._gcPressure);
    }
