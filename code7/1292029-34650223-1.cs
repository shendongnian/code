     private void PopulateListBox(ref ComboBox cmb, string Folder, string FileType)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Folder);
            FileInfo[] Files = dinfo.GetFiles(FileType);
            foreach (FileInfo file in Files)
            {
                var ext = Path.GetExtension(file.Name);
                var name = Path.GetFileNameWithoutExtension(file.Name);
                cmb.Items.Add(name);
            }
        }
