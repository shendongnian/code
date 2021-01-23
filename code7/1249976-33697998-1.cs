    public override void Process(ExpandInitialFieldValueArgs args)
    {
      Assert.ArgumentNotNull((object) args, "args");
      MasterVariablesReplacer variablesReplacer = Factory.GetMasterVariablesReplacer();
      string text = args.SourceField.Value;
      if (variablesReplacer == null)
        args.Result = text;
      else
        args.Result = variablesReplacer.Replace(text, args.TargetItem);
     }
