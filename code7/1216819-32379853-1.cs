    [assembly:ExportRenderer(typeof(BluetoothPage), typeof(BluetoothPageRenderer))]
    
    namespace CustomRenderer.iOS
    {
    	public class BluetoothPageRenderer : PageRenderer
    	{
    		protected override void OnElementChanged (ElementChangedEventArgs<ContentPage> e)
    		{
    			base.OnElementChanged (e);
    
    			var bluetoothPage = (BluetoothPage)e;
    
    			bluetoothPage.List.DoStuff();
    		}
    
    	}
    
    }
