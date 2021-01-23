    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using AndroidHUD;
    using MyExample.Services;
    using Xamarin.Forms;
    using XHUD;
    
    [assembly: Xamarin.Forms.Dependency(typeof(MyExample.Android.Services.HudService))]
    
    namespace MyExample.Android.Services
    {
        public class HudService : IHudService
        {
        		//Although, not well documented, for Xamarin.Forms, "Forms.Context" is the current activity
        
            public HudService()
            {
            }
    
            #region IHudService Members
    
            public void Show(string message, MyExample.Services.MaskType maskType, int progress)
            {
                AndHUD.Shared.Show(Forms.Context, message, progress, (AndroidHUD.MaskType)maskType);
            }
    
            public void Dismiss()
            {
                AndHUD.Shared.Dismiss(Forms.Context);
            }
    
            public void ShowToast(string message, bool showToastCentered = true, double timeoutMs = 1000)
            {
                AndHUD.Shared.ShowToast(Forms.Context, message, (AndroidHUD.MaskType)MyExample.Services.MaskType.Black, TimeSpan.FromSeconds(timeoutMs / 1000), showToastCentered);
            }
    
            public void ShowToast(string message, MyExample.Services.MaskType maskType, bool showToastCentered = true, double timeoutMs = 1000)
            {
                AndHUD.Shared.ShowToast(Forms.Context, message, (AndroidHUD.MaskType)maskType, TimeSpan.FromSeconds(timeoutMs / 1000), showToastCentered);
            }
    
            #endregion
        }
    
    }
