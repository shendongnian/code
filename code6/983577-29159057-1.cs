    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BigTed;
    using Foundation;
    using MyExample.Services;
    using UIKit;
    
    [assembly: Xamarin.Forms.Dependency(typeof(MyExample.iOS.Services.HudService))]
    
    namespace MyExample.iOS.Services
    {
        public class HudService : IHudService
        {
            public HudService()
            {
            }
    
            #region IHudService Members
    
            public void Show(string message, MaskType maskType, int progress)
            {
                float p = (float)progress / 100f;
                BTProgressHUD.Show(message, p, (ProgressHUD.MaskType)maskType);
            }
    
            public void Dismiss()
            {
                BTProgressHUD.Dismiss();
            }
    
            public void ShowToast(string message, bool showToastCentered = true, double timeoutMs = 1000)
            {
                BTProgressHUD.ShowToast(message, showToastCentered, timeoutMs);
            }
    
            public void ShowToast(string message, MaskType maskType, bool showToastCentered = true, double timeoutMs = 1000)
            {
                BTProgressHUD.ShowToast(message, (ProgressHUD.MaskType)maskType, showToastCentered, timeoutMs);
            }
    
            #endregion
        }
    }
