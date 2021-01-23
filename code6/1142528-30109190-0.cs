            DirectoryInfo directoryInfo = new DirectoryInfo(uploadDirectory);
            if (!directoryInfo.Exists)
            {
                Directory.CreateDirectory(uploadDirectory);
            }
            var sec = directoryInfo.GetAccessControl();
            var accessRule = new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow);
            sec.AddAccessRule(accessRule);
            directoryInfo.SetAccessControl(sec);
