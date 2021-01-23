    // for example:  (pseudo)
    _upload.SetNotes("");
    class UploadWindow
    {
        // ......
        public void SetNotes(string note)
        {
            _txtbxNotes.Dispatcher.Invoke(() =>
            {
                _txtbxNotes.Text = note;
            }));
        }
    }
