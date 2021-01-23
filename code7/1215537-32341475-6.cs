    public partial class Form1 : Form
    {
    private DirectoryController _controller;
    
    public Form1()
    {
        InitializeComponent();
        ImageList imgList = GetFolderImageList();
        InitializeListView(imgList);
        _controller = new DirectoryController("C:");
        OpenDirectory("");
    }
    
    private void InitializeListView(ImageList imgList)
    {
        lvExplorer.DoubleClick += new System.EventHandler(this.lvExplorer_DoubleClick);
        lvExplorer.SmallImageList = imgList;
        lvExplorer.LargeImageList = imgList;
    }
    
    private static ImageList GetFolderImageList()
    {
        Image folderImg = Image.FromFile(@"C:\Windows\WinSxS\amd64_microsoft-windows-printing-fdprint_31bf3856ad364e35_6.3.9600.17415_none_493b0b9e590044a1\folder.ico");
        ImageList imgList = new ImageList();
        imgList.Images.Add(folderImg);
        return imgList;
    }
    
    private void lvExplorer_DoubleClick(object sender, EventArgs e)
    {
        string path = lvExplorer.SelectedItems[0].Text;
        OpenDirectory(path);
    }
    
    private void OpenDirectory(string path)
    {
        try 
        {
            lvExplorer.Items.Clear();
            string newPath = _controller.AddDirectoryAndGetPath(path);
            ShowDirectoriesInListView(newPath);
        }
        catch (Exception ex) 
        {
            MessageBox.Show(ex.Message);
        }
    }
    
    private void ShowDirectoriesInListView(string path)
    {
        DirectoryInfo info = new DirectoryInfo(path);
    
        DirectoryInfo parent = info.Parent;
        if (parent != null) 
        {
            lvExplorer.Items.Add(new System.Windows.Forms.ListViewItem("...", 0));
        }
    
        foreach (DirectoryInfo dInfo in info.GetDirectories())
        {
            lvExplorer.Items.Add(new System.Windows.Forms.ListViewItem(dInfo.Name, 0));
        }
    }
    }
