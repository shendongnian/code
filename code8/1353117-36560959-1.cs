    [assembly:ExportRenderer (typeof(ButtonWithLongPressGesture), typeof(LongPressGestureRecognizerButtonRenderer))]
    namespace SampleApp.iOS
    {
        public class LongPressGestureRecognizerButtonRenderer : ButtonRenderer
        {
            ButtonWithLongPressGesture view;
    
            public ButtonPressGestureRecognizerImageRenderer ()
            {
                this.AddGestureRecognizer (new UILongPressGestureRecognizer ((longPress) => {
                    if (longPress.State == UIGestureRecognizerState.Began) {
                        view.HandleLongPress(view, new EventArgs());
                    }
                }));
            }
    
            protected override void OnElementChanged (ElementChangedEventArgs<Button> e)
            {
                base.OnElementChanged (e);
    
                if (e.NewElement != null)
                    view = e.NewElement as ButtonWithLongPressGesture;
            }
        }
    }
