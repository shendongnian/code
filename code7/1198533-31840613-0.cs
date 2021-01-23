        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            PackageImagesViewModel viewModel = this.DataContext as PackageImagesViewModel;
            VistaFolderBrowserDialog d = new VistaFolderBrowserDialog();
            d.Description = "Please select a network share";
            d.SelectedPath = viewModel.GetMediaFolder();
            bool? pathSelected = d.ShowDialog();
            if (pathSelected == false)
                return;
            string value = GetUncPath(d.SelectedPath);
            if (string.IsNullOrEmpty(value))
            {
                MessageBox.Show("The selected folder is not recognized as a network path.", "Invalid Target Directory");
                return;
            }
            viewModel.DestinationFolder = value;
        }
        private string GetUncPath(string path)
        {
            if (path.StartsWith("\\"))
                return path;
            try
            {
                ManagementObject mo = new ManagementObject();
                mo.Path = new ManagementPath(string.Format("Win32_LogicalDisk='{0}'", path.Substring(0, 2)));
                // DriveType 4 = Network Drive
                if (Convert.ToUInt32(mo["DriveType"]) == 4)
                    return Convert.ToString(mo["ProviderName"]) + path.Substring(2);
                else
                    return string.Empty;
            }
            catch { return string.Empty; }
        }
