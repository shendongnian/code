    // for example:  (pseudo)
    _upload.SetNotes("");
    class UploadWindow
    {
        // ......
        public void SetNotes(string note)
        {
            _txtbxNotes.Dispatcher.Invoke(Action)(() =>
            {
                _txtbxNotes.Text = "";
            }));
        }
    }
