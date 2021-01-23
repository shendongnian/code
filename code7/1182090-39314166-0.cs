    * First create a derivated class from Entry
    
        public class KBLessEntry : Entry
        { 
        public KBLessEntry() : base()
        {
        }
        }
    
    * Then create a custom platform EntryRender
    
        using Xamarin.Forms.Platform.Android;
        using Xamarin.Forms;
        using MobileClients.Droid.Core;
        using Android.Views.InputMethods;
        using System;
        using System.ComponentModel;
    
    [assembly: ExportRenderer(typeof(KBLessEntry), typeof(KBLessEntryRender))]
    namespace MobileClients.Droid.Core
    {
        public class KBLessEntryRender : EntryRenderer
        {
            protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                base.OnElementPropertyChanged(sender, e);
                Control.InputType = 0;
                try
                {             
                    // Hide keyboard
                    InputMethodManager inputMethodManager = this.Control.Context.GetSystemService(Android.Content.Context.InputMethodService) as InputMethodManager;
                    if (inputMethodManager != null)
                    {
                        inputMethodManager.HideSoftInputFromWindow(this.Control.WindowToken, HideSoftInputFlags.None);
                    }
                }
                catch(Exception Ex)
                {
    
                }
            }
    
        }
    }
