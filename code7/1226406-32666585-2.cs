    using System;
    using System.Collections.Specialized;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    using System.Diagnostics;
    using System.IO;
    
    namespace WpfRichTextBox._32648134
    {
        /// <summary>
        /// Interaction logic for Win32648134.xaml
        /// </summary>
        public partial class Win32648134 : Window
        {
            public Win32648134()
            {
                InitializeComponent();
            }
    
            private void BtnCopyImgFile_Click(object sender, RoutedEventArgs e)
            {              
                Image i = new Image();
    
                if (Clipboard.ContainsFileDropList())
                {
                    StringCollection fileNames = Clipboard.GetFileDropList();
                    BitmapImage img = new BitmapImage(new Uri(fileNames[0], UriKind.Absolute));
                    i.Source = img;
                    Para1.Inlines.Add(i);
                }     
    
                Para1.Inlines.Add(new Run("first rtb app"));
            }
    
            private void BtnSave_Click(object sender, RoutedEventArgs e)
            {
                TextRange allText = new TextRange(RtbCompose.Document.ContentStart, RtbCompose.Document.ContentEnd);
    
                FileStream stream = new FileStream(@"I:\RTB.rtf", FileMode.Create);
    
                allText.Save(stream, DataFormats.Rtf);
    
                if (stream != null)
                    stream.Close();
            }
    
            private void BtnCopyImgData_Click(object sender, RoutedEventArgs e)
            {
                bool hasImgData = Clipboard.ContainsImage();
                Image i = new Image();
                if (hasImgData)
                {
                    BitmapSource imgData = (BitmapSource)ImageCode.ImageFromClipboardDibAsSource();
                    i.Source = imgData;
                  
                    Para1.Inlines.Add(i);
                }
    
                Para1.Inlines.Add(new Run("rtb app, image comes from image data instead of file"));
            }
        }
    }
