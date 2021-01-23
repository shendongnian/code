            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("xyz.project.Folder1.Folder2.SomeFile.Txt"))
            {
                TextReader tr = new StreamReader(stream);
                string fileContents = tr.ReadToEnd();
            }
