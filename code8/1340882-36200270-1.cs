    public DynamicSummaryStatistics(Range range, SummaryStatisticsBool doCalculate)
    {
        var functionToRun = (arg1, arg2) => Globals.ThisAddIn.Application.ActiveWorkbook.Names.Add(arg1, arg2);
        this.ComputeDynamicSummaryStatistics(range, doCalculate, functionToRun);
    }
    public DynamicSummaryStatistics(Worksheet sheet, Range range, SummaryStatisticsBool doCalculate)
    {
        var functionToRun = (arg1, arg2) => sheet.Names.Add(arg1, arg2);
        this.ComputeDynamicSummaryStatistics(range, doCalcualte, functionToRun);
    }
    private void ComputeDynamicSummaryStatistics(Range range, SummaryStatisticsBool doCalculate, Func<string, string, Name> functionToRun)
    {
        var name = ((Name)range.Name).Name;
        if(doCalculate.Mean) Mean = functionToRun(name + "_MEAN", "=AVERAGE(" + name + ")");
        if(doCalculate.Variance) Variance = functionToRun(name + "_VAR", "=VAR.S(" + name + ")");
        // etc. etc.
    }
