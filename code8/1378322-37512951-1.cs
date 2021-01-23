    using System.Web;
    using IPlugins;
    public class AwesomePlugin : IPlugins.IPlugin
    {
	private string _Name = "AwesomePlugin";
	private HttpContext _Context;
	public string Name {
		get { return _Name; }
		set { _Name = value; }
	}
	public string Output {
		get { return "Yay !!!"; }
		set {
			throw new NotImplementedException();
		}
	}
	public void Display()
	{
		throw new NotImplementedException();
	}
	public void Dispose()
	{
		throw new NotImplementedException();
	}
	public void Load(ref Web.HttpContext Context)
	{
	}
    }
