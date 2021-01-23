    // for example:  (pseudo)
    _upload.SetNotes("");
    class UploadWindow
    {
        // ......
        public void SetNotes(string note)
        {
            _txtbxNotes.Invoke(Action)(() =>
            {
                _txtbxNotes.Text = "";
            }));
        }
    }
