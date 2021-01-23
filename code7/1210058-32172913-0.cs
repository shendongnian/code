	public interface IBasePage
	{
		string Header { get; }
	}
	public class MyPageA : ViewModelBase, IBasePage
	{
		public string Header { get { return "Page A"; } }
	}
	public class MyPageB : ViewModelBase, IBasePage
	{
		public string Header { get {return "Page B";} }
	}
	public class MyPageC : ViewModelBase, IBasePage
	{
		public string Header { get {return "Page C";} }
	}
