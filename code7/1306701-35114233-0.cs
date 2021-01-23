    string menuCommand = string.Format("\"{0}\" Copy \"%L\"", Application.ExecutablePath);
    // register the context menu
    FileShellExtension.Register(Program.FileType,
					Program.KeyName, Program.MenuText,
					menuCommand);
    string menuCommand1 = string.Format("\"{0}\" List \"%L\"", Application.ExecutablePath);
    // register the context menu 1
    FileShellExtension.Register(Program.FileType,
                    Program.KeyName1, Program.MenuText1,
                    menuCommand1);
