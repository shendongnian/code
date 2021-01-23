            string rootPath = Android.App.Application.Context.GetExternalFilesDir(null).ToString();
            var filePathDir = Path.Combine(rootPath, "Folder");
            if (!File.Exists(filePathDir))
            {
                Directory.CreateDirectory(filePathDir);
            }
