    if (e.Changes.Any(change => change is RoleEnvironmentConfigurationSettingChange)){
    Trace.WriteLine("with recycle");
    e.Cancel = true;
    }
    else {
    Trace.WriteLine("without recycle");
	e.Cancel = false;
    }
