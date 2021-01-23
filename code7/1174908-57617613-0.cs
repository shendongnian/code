    public interface IFolderBrowserDialogWrapper
    {
        string SelectedPath { get; set; }
        string Description { get; set; }
        DialogResult ShowDialog();
    }
