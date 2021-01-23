    public class FakeFolderBrowserDialogWrapper : IFolderBrowserDialogWrapper
    {
        private readonly DialogResult m_result;
        private readonly string m_selectedPath;
        public DialogResult ShowDialog()
        {
            return m_result;
        }
        public string SelectedPath
        {
            get { return m_selectedPath; }
        }
        public FakeFolderBrowserDialogWrapper(string selectedPath, DialogResult result)
        {
            m_selectedPath = selectedPath;
            m_result = result;
        }
    }
