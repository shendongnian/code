	public class MyViewModel : ViewModelBase
	{
		private IEnumerable<IBasePage> _MyPages = new List<IBasePage>(){
			new MyPageA(),
			new MyPageB(),
			new MyPageC()
		};
		public IEnumerable<IBasePage> MyPages {get {return this._MyPages;}}
	}
