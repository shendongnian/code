    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Windows.Media.Imaging;
    
    namespace WpfApplication13
    {
        public class VmMainWindow : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public List<VmItemInGrid> Items { get; }
    
            public VmMainWindow()
            {
                Items = new List<VmItemInGrid>
                {
                    new VmItemInGrid {Name = "Item1"},
                    new VmItemInGrid {Name = "Item2"},
                    new VmItemInGrid {Name = "Item3"}
                };
            }
        }
    
        public class VmItemInGrid : INotifyPropertyChanged
        {
            private const string generalBmpPath = @"C:\Users\Gil\Pictures\TestBMPs\";
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            private string filepath;
    
            public VmItemInGrid()
            {
                GetNextFile();
            }
    
            public string Name { get; set; }
    
            public BitmapImage BMP
            {
                get
                {
                    var buffer = new BitmapImage();
                    using (Stream imageStreamSource = new FileStream(filepath,
                        FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        buffer.BeginInit();
                        buffer.CacheOption = BitmapCacheOption.OnLoad;
                        buffer.StreamSource = imageStreamSource;
                        buffer.EndInit();
                    }
                    return buffer;
                }
            }
            
            public void GetNextFile()
            {
                var allFiles = Directory.GetFiles(generalBmpPath, "*.bmp");
                var random = new Random();
                var index = random.Next(allFiles.Length);
                filepath = allFiles[index];
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BMP)));
            }
        }
    }
