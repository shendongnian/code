    using System.Web;
    public interface IPlugin
    {
	string Name { get; set; }
	string Output { get; set; }
	void Load(ref httpcontext Context);
	void Dispose();
	void Display();
    }
