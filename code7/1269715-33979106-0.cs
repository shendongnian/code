            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string path = appData + "\\Lua";
            string[] fileArray = Directory.GetFiles(path, "*.lua");
            for (int i = 0; i < fileArray.Length; i++)
            {
                string Name = Path.GetFileName(fileArray[i]);
                string PathToLua = fileArray[i];
                //ScriptsBoxBox.Items.AddRange(Name.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries));
                // Console.WriteLine();
                Console.WriteLine(ScriptsBoxBox.CheckedItems.Contains(Name));
                var pathname = ScriptsBoxBox.CheckedItems.Contains(Name);
                if (ScriptsBoxBox.CheckedItems.Contains(Name))
                {
                    System.Diagnostics.Process.Start("notepad.exe", fileArray[ScriptsBoxBox.CheckedItems.IndexOf(Name)]); // I supposed this would get the correct name index, and it did! fileArray by default seems to get the path of the file.
                }
