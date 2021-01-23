    EnvDTE.Properties generalProps = dte2Obj.Properties["Environment", "General"];
    for (int i = 1; i <= generalProps.Count; ++i)
    {
        System.Diagnostics.Debug.WriteLine(
            generalProps.Item(i).Name + ": " + generalProps.Item(i).Value);
    }
