    if (dlgFileBrowse.ShowDialog() == DialogResult.OK)
            {
                // Validate the file selection.
                if (IsValidFileSelectiom(dlgFileBrowse.FileNames))
                {
                    // Processing my files here.
                }
                else
                {
                    // Display selection criterion.
                    this.UiMessage = "Please select one log/lfa file or multiple log files.";
                }
            }
