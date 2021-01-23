    public partial class MainPage : PhoneApplicationPage
    {
    	private InterstitialAd interstitialAd;
    	int Click1 = 0;
    	AdRequest adRequest = new AdRequest();
    	  
    	public MainPage()
    	{
    		InitializeComponent();          
    				   
    	 }
    	private void Button_Click(object sender, RoutedEventArgs e)
    	{
    		Click1++;
    		if (Click1 == 5)
    		{
    			interstitialAd = new InterstitialAd("My APp Id");
    			AdRequest adRequest = new AdRequest();
    	  
    			  interstitialAd.ReceivedAd += OnAdReceived;
    			interstitialAd.LoadAd(adRequest);
    			Click1 = 0;
    		}
    	}
    	private void OnAdReceived(object sender, AdEventArgs e)
    	{
    		System.Diagnostics.Debug.WriteLine("Ad received successfully");
    		interstitialAd.ShowAd();   
    	}
    }
