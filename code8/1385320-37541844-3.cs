    private ObservableCollection<EasyRunBinSerializableData.TracefieldPartProgramClass> SortOnTracefield(ObservableCollection<EasyRunBinSerializableData.TracefieldPartProgramClass> obcToSort)
    {
        var sorted = obcToSort.OrderBy(w => w.obcTraceFieldPartProgram[0].Item3.ToString();
        return new ObservableCollection<EasyRunBinSerializableData.TracefieldPartProgramClass>(sorted);
    }
