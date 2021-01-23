        public string PromptForDirectorySelection(string summary, string initialPath)
        {
            var browserDialog = new CommonOpenFileDialog
            {
                Title = summary,
                IsFolderPicker = true,
                InitialDirectory = initialPath,
                AddToMostRecentlyUsedList = true,
                AllowNonFileSystemItems = false,
                EnsureFileExists = false,
                EnsurePathExists = true,
                EnsureReadOnly = false,
                EnsureValidNames = true,
                Multiselect = false,
                ShowPlacesList = true
            };
            // get the current active window, prior to showing and closing this dialog, so it can be re-focused later.
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.IsActive);
            var dialogResult = browserDialog.ShowDialog();
            if (null != window)
            {
                window.Focus();
            }
            if (dialogResult == CommonFileDialogResult.Ok)
            {
                return browserDialog.FileName;
            }
            return null;
        }
