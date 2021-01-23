    [assembly: ExportRenderer(typeof(ScannerSearchBar), typeof(ScannerSearchBardRenderer))]
    namespace HideKeyboard.iOS
    {
        public class ScannerSearchBarRenderer : SearchBarRenderer
        {
            protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.SearchBar> e)
            {
                base.OnElementChanged(e);
                if (Control != null)
                {
                    if (Focused)
                    {
                        ResignFirstResponder();
                    }
                }
            }
        }
    }
