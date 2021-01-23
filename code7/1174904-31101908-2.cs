    public class FolderBrowserDialogWrapper : IFolderBrowserDialogWrapper
    {
        private readonly FolderBrowserDialog m_dialog;
        public DialogResult ShowDialog()
        {
            return m_dialog.ShowDialog();
        }
        public string SelectedPath
        {
            get { return m_dialog.SelectedPath; }
        }
        public FolderBrowserDialogWrapper(FolderBrowserDialog dialog)
        {
            m_dialog = dialog;
        }
    }
