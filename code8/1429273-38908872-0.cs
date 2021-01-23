    while (result == DialogResult.Retry) {
            if (dialog.ShowDialog() != DialogResult.OK) {
                    MyLog.Write(@"File Retrieval was Unsuccessful", LogFormat.Result);
                    MyLog.Write("No File Selected", LogFormat.Error);
                result = MessageBox.Show(@"Please select a file..", @"No File Selected!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation);
                    if (result == DialogResult.Abort) throw;
                        return null;
                } else {
                    MyLog.Write($"FilePath: {dialog.FileName}", LogFormat.Process);
                    MyLog.Write(@"File Retrieval was Successful", LogFormat.Result);
                    _lastFilePath = Path.GetDirectoryName(dialog.FileName);
                    return dialog.FileName;
                }
        }
