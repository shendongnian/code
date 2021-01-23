    For Andorid
                
        [assembly: ExportRenderer(typeof(Button), typeof(CustomButtonRenderer))]
        namespace WalkieTalkie.Droid.Renderer
        {
            public class CustomButtonRenderer : ButtonRenderer
            {
                protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
                {
                    base.OnElementChanged(e);
                    var customButton = e.NewElement as CustomButton;
                    var thisButton = Control as Android.Widget.Button;
                    thisButton.Touch += (object sender, TouchEventArgs args) =>
                    {
                        if (args.Event.Action == MotionEventActions.Down)
                        {
                            customButton.OnPressed();
                        }
                        else if (args.Event.Action == MotionEventActions.Up)
                        {
                            customButton.OnReleased();
                        }
                    };
                }
            }
        }
    For IOS
        [assembly: ExportRenderer(typeof(CustomButton), typeof(CustomButtonRenderer))]
        namespace WalkieTalkie.iOS.Renderer
        {
            public class CustomButtonRenderer : ButtonRenderer
            {
                protected override void    OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
                {
                    base.OnElementChanged(e);
                    var customButton = e.NewElement as CustomButton;
                    var thisButton = Control as UIButton;
                    thisButton.TouchDown += delegate
                    {
                        customButton.OnPressed();
                    };
                    thisButton.TouchUpInside += delegate
                    {
                        customButton.OnReleased();
                    };
                }
            }
        }
