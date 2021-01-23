    public class FolderBrowserDialogWrapper : IFolderBrowserDialogWrapper
    {
        private FolderBrowserDialog _dialog;
        public FolderBrowserDialogWrapper()
        {
            _dialog = new FolderBrowserDialog();
        }
        public DialogResult ShowDialog()
        {
            return _dialog.ShowDialog();
        }
        public string SelectedPath
        {
            get { return _dialog.SelectedPath;  }
            set { _dialog.SelectedPath = value; }
        }
        public string Description
        {
            get { return _dialog.Description; }
            set { _dialog.Description = value; }
        }
    }
