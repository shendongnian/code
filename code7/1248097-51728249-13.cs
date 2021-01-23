    using System;
    using System.IO;
    using System.Drawing;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Foundation;
    using Xamarin.Forms;
    using TestUIImage.Services;
    namespace TestUIImage.Views
    {
        public partial class MainPage : ContentPage
        {
            public MainPage()
            {
                InitializeComponent();
            }
            async void Handle_Clicked(object sender, System.EventArgs e)
            {
                PickPictureButton.IsEnabled = false;
                NSUrl nSUrl = await DependencyService.Get<IPicturePicker>().GetNSUrlAsync();            
                TestImage.Source = ImageSource.FromStream(() =>
                {
                    var ms = new MemoryStream();              
                    var imagebytes = File.ReadAllBytes(nSUrl.Path);
                    ms.Write(imagebytes, 0, imagebytes.Length);
                    ms.Seek(0, SeekOrigin.Begin);
                    return ms;
                });
                PickPictureButton.IsEnabled = true;
            }
        }
    }
