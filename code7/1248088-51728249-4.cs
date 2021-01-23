    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using System.IO;
    using Foundation;
    namespace TestUIImage.Services
    {
        public interface IPicturePicker
        {
            Task<NSUrl> GetNSUrlAsync();
        }
    }
