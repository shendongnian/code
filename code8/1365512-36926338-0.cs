    static object[] FileInfoCases = {
      new object[] {
        new Dictionary<string, List<BackupFileInfo>>() {
          ["source"] = new List<BackupFileInfo>() {
            new BackupFileInfo() {
              FileName = "",
              FileLastChanged = new DateTime(),
              FullPath =""
            }
          },
          ["destination"] = new List<BackupFileInfo>() { }
        }
      }
    };
