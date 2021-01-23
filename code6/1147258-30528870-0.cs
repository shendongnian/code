       public partial class Form1 : Form
       {
        ImageList list = new ImageList();
    
        public Form1()
        {
          InitializeComponent();
          GetImages();
        }
    
        private void GetImages()
        {
          string path = @"C:\ImgFolder";
          string[] filter = { ".bmp", ".jpg", ".jpeg", ".png" };
          DirectoryInfo directoryInfo = new DirectoryInfo(path);
          FileInfo[] fileInfo = directoryInfo.GetFiles();
          ArrayList arrayList = new ArrayList();
    
          foreach (FileInfo fi in fileInfo.Where(f => f.CreationTime >= YourFromDateVariable && f.CreationTime <= YourToDateVariable))
            foreach (string s in filter)
              if (s == fi.Extension)
                arrayList.Add(fi.FullName);
    
          //adding files to image list:
          for (int i = 0; i < arrayList.Count; i++)
          {
            Image img = Image.FromFile(arrayList[i].ToString());
            list.Images.Add(img);
          }
        }
      }
