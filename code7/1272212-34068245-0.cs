    string fileName ="ProjectSettings.Json";
    ProjectSettings readProjectSettings;
    if (File.Exists(fileName))
    {
        readProjectSettings = JsonConvert.DeserializeObject<ProjectSettings>(File.ReadAllText(fileName));
    }
    else
    {
        readProjectSettings = new ProjectSettings();
    }
    Settings.decProp1 = readProjectSettings.decProp1;
