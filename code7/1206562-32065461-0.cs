    var s = minifier.MinifyJavaScript(code, new CodeSettings
    {
      RemoveUnneededCode = true,
      PreserveImportantComments = false,
      LocalRenaming = LocalRenaming.CrunchAll,
      EvalTreatment = EvalTreatment.MakeAllSafe,
      OutputMode = OutputMode.SingleLine,
      PreserveFunctionNames = false                        
    });
    Console.WriteLine(s);
