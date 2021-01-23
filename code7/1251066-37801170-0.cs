    [PostProcessBuild]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string path)
    {
        // Go get pbxproj file
        string projPath = path + "/Unity-iPhone.xcodeproj/project.pbxproj";
        // PBXProject class represents a project build settings file,
        // here is how to read that in.
        PBXProject proj = new PBXProject ();
        proj.ReadFromFile (projPath);
        // This is the Xcode target in the generated project
        string target = proj.TargetGuidByName ("Unity-iPhone");
        // Copy plist from the project folder to the build folder
        FileUtil.CopyFileOrDirectory ("Assets/EditUI.plist", path + "/EditUI.plist");
        proj.AddFileToBuild (target, proj.AddFile("EditUI.plist", "EditUI.plist"));
        // Write PBXProject object back to the file
        proj.WriteToFile (projPath);
    }
