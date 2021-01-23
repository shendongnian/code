            DirectoryInfo di = new DirectoryInfo("C:\\Image");
            FileSystemInfo[] fi = di.GetFileSystemInfos("*.bmp");
            Array.Sort(fi, new SortByNum());
    public class SortByNum : IComparer<FileSystemInfo>
    {
        public int Compare( FileSystemInfo x, FileSystemInfo y)
        {
            // extract the numeric portion of the file name
            int val_x = int.Parse(x.Name.Split('_')[1].Substring(0, x.Name.Split('_')[1].Length - x.Extension.Length));
            int val_y = int.Parse(y.Name.Split('_')[1].Substring(0, y.Name.Split('_')[1].Length - y.Extension.Length));
            return val_x.CompareTo(val_y);
        }
    }
