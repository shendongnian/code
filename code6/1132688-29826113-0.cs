    public partial class TestPage : ContentPage
    {	
    	public TestPage ()
    	{
    		InitializeComponent ();
    	}
    
        private void startPanic(object sender, EventArgs args){
            Device.BeginInvokeOnMainThread (() => {
                start_btn.IsVisible = false;
                stop_btn.IsVisible = true;  
            });
        }
    }
