    using System;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Input;
    
    namespace NeoSmart.Dialogs
    {
        class HotkeyContentDialog : ContentDialog
        {
            public new event TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> PrimaryButtonClick;
            public new event TypedEventHandler<ContentDialog, ContentDialogButtonClickEventArgs> SecondaryButtonClick;
    
            public ContentDialogResult Result { get; set; }
            public new async Task<ContentDialogResult> ShowAsync()
            {
                var baseResult = await base.ShowAsync();
                if (baseResult == ContentDialogResult.None)
                {
                    return Result;
                }
                return baseResult;
            }
    
            protected override void OnKeyUp(KeyRoutedEventArgs e)
            {
                if (e.Key == Windows.System.VirtualKey.Enter)
                {
                    Result = ContentDialogResult.Primary;
                    PrimaryButtonClick?.Invoke(this, default(ContentDialogButtonClickEventArgs));
                    Hide();
                }
                else if (e.Key == Windows.System.VirtualKey.Escape)
                {
                    Result = ContentDialogResult.Secondary;
                    SecondaryButtonClick?.Invoke(this, default(ContentDialogButtonClickEventArgs));
                    Hide();
                }
                else
                {
                    base.OnKeyUp(e);
                }
            }
        }
    }
