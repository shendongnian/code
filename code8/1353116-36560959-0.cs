    [assembly: Xamarin.Forms.ExportRenderer (typeof (MyButton), typeof (MyButtonRenderer))]
    namespace MyApp.Android
    {   
        public class MyButtonRenderer : ButtonRenderer
        {
            protected override void OnElementChanged (ElementChangedEventArgs<global::Xamarin.Forms.Button> e)
                    {
                        base.OnElementChanged (e);
                        if (e.OldElement == null) {
                            var nativeButton = Control;
                            nativeButton.LongClick += delegate {
                                //Do something
                            };
                        }
                    }
        }
    }
