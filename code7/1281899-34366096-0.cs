    engine.AutoPrint = true;
    //samples taken from ?fscores man page in package mirt
    engine.Evaluate("library(mirt)");
    // 'Science' is a prepackage sample data in mirt; you can use 'engine.CreateDataFrame' in C# to create your own if need be.
    engine.Evaluate("mod <- mirt(Science, 1)");
    engine.Evaluate("class(mod)");
    S4Object modcs = engine.GetSymbol("mod").AsS4();
    IDictionary<string, string> slotTypes = modcs.GetSlotTypes();
    if (slotTypes.Keys.Contains("Fit"))
    {
        GenericVector fit = modcs["Fit"].AsList();
        // should check logLik in fit.Names;
        double logLik = fit["logLik"].AsNumeric()[0];
    }
    engine.Evaluate("tabscores <- fscores(mod, full.scores = FALSE)");
    engine.Evaluate("head(tabscores)");
    engine.Evaluate("class(tabscores)");
    NumericMatrix tabscorescs = engine.GetSymbol("tabscores").AsNumericMatrix();
