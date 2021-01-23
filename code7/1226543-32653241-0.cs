    public class ReadAsset : Activity
    {
	protected override void OnCreate (Bundle bundle)
	{
		base.OnCreate (bundle);
		InputStream input = Assets.Open ("my_asset.txt");
	}
    }  
