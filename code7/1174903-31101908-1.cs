    public interface IFolderBrowserDialogWrapper
    {
        DialogResult ShowDialog();
        string SelectedPath { get; }
    }
