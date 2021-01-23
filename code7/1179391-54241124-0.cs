public class ChromiumLifeSpanHandler : ILifeSpanHandler
    {
        public bool DoClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return false;
        }
        public void OnAfterCreated(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
        }
        public void OnBeforeClose(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
        }
        public bool OnBeforePopup(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, string targetFrameName, WindowOpenDisposition targetDisposition, bool userGesture, IPopupFeatures popupFeatures, IWindowInfo windowInfo, IBrowserSettings browserSettings, ref bool noJavascriptAccess, out IWebBrowser newBrowser)
        {
            newBrowser = null;
            System.Diagnostics.Process.Start(targetUrl);
            return true;
        }
    }
Here is how I implemented it in WPF (I just stuck it in a grid to have a place to show the static resource): 
`
<Grid>
    <Grid.Resources>
        <local:ChromiumLifeSpanHandler x:Key="popupHander"/>
    </Grid.Resources>
    <cef:ChromiumWebBrowser Address="{Binding TwitterFeedAddress}" 
                            LifeSpanHandler="{StaticResource popupHandler}"/>
</Grid>
