    using CustomrendersAll.customRenders;
    using Xamarin.Forms.Platform.Android;
    using Xamarin.Forms;
    using CustomrendersAll.Droid.customRenders;
    [assembly: ExportRenderer(typeof(MyEntry), typeof(customRenderAndriod))]
    namespace CustomrendersAll.Droid.customRenders
    {
        public class customRenderAndriod : EntryRenderer
        {  
                protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
                {
                    base.OnElementChanged(e);
                    if (Control != null)
                    {
                        Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
                    
                    }
                }
           
        }
    }
