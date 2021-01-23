    public class ContentViewController : UIViewController
	{
		private int index = -1;
		public int Index{
			get{ 
				return index;
			}
		}
		public ContentViewController (int _index,UIColor backColor)
		{
			this.index = _index;
			this.View.Frame = UIScreen.MainScreen.Bounds;
			this.View.BackgroundColor = backColor;
		}
	}
