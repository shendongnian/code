    #addin "Newtonsoft.Json"
    // fake a release note
    ReleaseNotes releaseNotes = new ReleaseNotes(
        new Version("3.0.0"),
        new [] {"3rd release"},
        "3.0.-beta"
        );
    // project.json to patch
    FilePath filePaths = File("./project.json");
    // patch project.json
    UpdateProjectJsonVersion(releaseNotes.RawVersionLine, filePaths);
    // utility function that patches project.json using json.net
    public static void UpdateProjectJsonVersion(string version, FilePath projectPath)
    {
        var project = Newtonsoft.Json.Linq.JObject.Parse(
            System.IO.File.ReadAllText(projectPath.FullPath, Encoding.UTF8));
        project["version"].Replace(version);
        System.IO.File.WriteAllText(projectPath.FullPath, project.ToString(), Encoding.UTF8);
    }
