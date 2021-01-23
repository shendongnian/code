    string filepath = @"F:\first_folder\Node3_V_1.3";
    string filename = Path.GetFileName(filepath);
    string[] parts = filename.Split(new[] { "_V_" }, 2, StringSplitOptions.None);
    string output = string.Format("upgrading {0} to version {1}",
                                  parts[0],
    							  parts[1]);
