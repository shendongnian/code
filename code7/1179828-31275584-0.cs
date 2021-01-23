    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Text;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.Storage;
    using Windows.System;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    using Xfinium.Pdf;
    using Xfinium.Pdf.Actions;
    using Xfinium.Pdf.Core;
    using Xfinium.Pdf.Graphics;
    using Xfinium.Pdf.Graphics.FormattedContent;
    
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641
    
    namespace App40
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
    
                this.NavigationCacheMode = NavigationCacheMode.Required;
            }
    
            /// <summary>
            /// Invoked when this page is about to be displayed in a Frame.
            /// </summary>
            /// <param name="e">Event data that describes how this page was reached.
            /// This parameter is typically used to configure the page.</param>
            protected override void OnNavigatedTo(NavigationEventArgs e)
            {
                // TODO: Prepare page for display here.
    
                // TODO: If your application contains multiple pages, ensure that you are
                // handling the hardware Back button by registering for the
                // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
                // If you are using the NavigationHelper provided by some templates,
                // this event is handled for you.
            }
    
            private  void Button_Click(object sender, RoutedEventArgs e)
            {
            }
    
    
            //this is a tutrila can help you with simple text
            private async void Button_Click1(object sender, RoutedEventArgs e)
            {
    
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("a.pdf", CreationCollisionOption.ReplaceExisting);
                using (Stream stream = await WindowsRuntimeStorageExtensions.OpenStreamForWriteAsync(file))
                {
                    PdfFixedDocument document = new PdfFixedDocument();
                    PdfPage page = document.Pages.Add();
                    // Create a standard font with Helvetica face and 24 point size
                    PdfStandardFont helvetica = new PdfStandardFont(PdfStandardFontFace.Helvetica, 24);
                    // Create a solid RGB red brush.
                    PdfBrush brush = new PdfBrush(PdfRgbColor.Red);
                    // Draw the text on the page.
                    string cha = "title";
                    page.Graphics.DrawString(cha, helvetica, brush, 250, 50);
                    // Draw the text on the page. max tableau 50
                    string ch = "azj aeiajiahfioe foiehfioehfiehfie feifjaepfjaepofjaepo fpaejfpeafjaefaefhevpzevje vjepzvihzev zep";
                    page.Graphics.DrawString(ch, helvetica, brush, 10, 100);
                    
                    document.Save(stream);
                    
    
                }
                await Launcher.LaunchFileAsync(file);
    
                //FileStream input = File.OpenRead("optionalcontent-src.pdf");
                //PdfFile file = new PdfFile(input);
                
            }
    
            //this is a tutrila can help you with paragraph block
            private async void Button_Click2(object sender, RoutedEventArgs e)
            {
                var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("a.pdf", CreationCollisionOption.ReplaceExisting);
                using (Stream stream = await WindowsRuntimeStorageExtensions.OpenStreamForWriteAsync(file))
                {
                    string paragraph2Block1Text = "The development style is based on fixed document model, where each page is created as needed " +
                    "and content is placed at fixed position using a grid based layout.\r\n" +
                    "This gives you access to all PDF features, whether you want to create a simple file " +
                    "or you want to create a transparency knockout group at COS level, and lets you build more complex models on top of the library.";
    
                    PdfStandardFont textFont = new PdfStandardFont(PdfStandardFontFace.TimesRoman, 12);
    
                    PdfFormattedParagraph paragraph2 = new PdfFormattedParagraph();
                    paragraph2.SpacingAfter = 3;
                    paragraph2.FirstLineIndent = 10;
                    paragraph2.HorizontalAlign = PdfStringHorizontalAlign.Justified;
                    paragraph2.LineSpacingMode = PdfFormattedParagraphLineSpacing.Multiple;
                    paragraph2.LineSpacing = 1.2;
                    paragraph2.Blocks.Add(new PdfFormattedTextBlock(paragraph2Block1Text, textFont));
    
                    PdfFormattedContent formattedContent = new PdfFormattedContent();
                    formattedContent.Paragraphs.Add(paragraph2);
    
                    PdfFixedDocument document = new PdfFixedDocument();
                    PdfPage page = document.Pages.Add();
    
                    page.Graphics.DrawFormattedContent(formattedContent, 50, 50, 500, 700);
                    page.Graphics.CompressAndClose();
    
                    document.Save(stream);
                }
                await Launcher.LaunchFileAsync(file);
            }
        }
    }
