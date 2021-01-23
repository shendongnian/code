    public class ScrollViewDelegate : UIScrollViewDelegate
	{
		public override void Scrolled(UIScrollView scrollView)
        {
            Console.WriteLine("Scrolled");
        }
	}
    ContractWebView.ScrollView.Delegate = new ScrollViewDelegate();
