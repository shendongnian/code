      string fl = Application.StartupPath + "\\BarCode.txt";
      string StrFileName = "Barcode.txt";
      int intFN;
      intFN = FileSystem.FreeFile();
      FileSystem.FileOpen(intFN, fl, OpenMode.Output, OpenAccess.Default,OpenShare.Default, 1024);
      // Write Text In File FileSystem.PrintLine(intFN, "TEST");
      FileSystem.FileClose(intFN);
      Microsoft.VisualBasic.Interaction.Shell(Application.StartupPath + "\\PRINT.BAT " + pStrFileName, AppWinStyle.Hide, false, -1);
 
