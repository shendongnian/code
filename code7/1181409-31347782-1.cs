    var exeConfiguration = ConfigurationManager.OpenExeConfiguration(
          ConfigurationUserLevel.PerUserRoamingAndLocal);
    var userSettings = exeConfiguration.GetSectionGroup("userSettings");
    var executiveBranch = (ExecutiveBranchSection)userSettings.Sections.Get(
            ExecutiveBranchSection.Tag);
    var presidents = executiveBranch.Presidents;
    foreach (President president in presidents)
    {
        Console.WriteLine("{0}: {1}", president.Name, president.Legacy);
    }
