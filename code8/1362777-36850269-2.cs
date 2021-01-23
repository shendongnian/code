    public class ViewController : UIViewController
    	{
    		private Test _test;
    
    		public override void ViewDidLoad()
    		{
    			_test = new Test();
    			base.ViewDidLoad();
    		}
    
    		public override void ViewWillAppear(bool animated)
    		{
    			base.ViewWillAppear(animated);
    			_test.TitleChanged += Test_TitleChanged;
    		}
    
    		public override void ViewDidDisappear(bool animated)
    		{
    			_test.TitleChanged -= Test_TitleChanged;
    			base.ViewDidDisappear(animated);
    		}
    
    		void Test_TitleChanged(object sender, TitleChangedEventArgs e)
    		{
    			Console.WriteLine("Title Changed! " + e.Title);
    		}
    
    		public override void ViewWillDisappear(bool animated)
    		{
    			base.ViewWillDisappear(animated);
    		}
    	}
