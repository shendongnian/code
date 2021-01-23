    public class HotkeyContentDialog : ContentDialog
    {
        public new event TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> PrimaryButtonClick;
        public new event TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> SecondaryButtonClick;
        public ContentDialogResult Result { get; set; }
        public new async Task<ContentDialogResult> ShowAsync()
        {
            var baseResult = await base.ShowAsync();
            return baseResult == ContentDialogResult.None ? Result : baseResult;
        }
        protected override void OnKeyUp(KeyRoutedEventArgs e)
        {
            switch (e.Key)
            {
                case Windows.System.VirtualKey.Enter:
                    Result = ContentDialogResult.Primary;
                    PrimaryButtonClick?.Invoke(this, default);
                    Hide();
                    break;
                case Windows.System.VirtualKey.Escape:
                    Result = ContentDialogResult.Secondary;
                    SecondaryButtonClick?.Invoke(this, default);
                    Hide();
                    break;
                default:
                    base.OnKeyUp(e);
                    break;
            }
        }
    }
