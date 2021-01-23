    public class SecurityPermissions
    {
    	public bool Add { get; set; }
    	public bool Change { get; set; }
    }
    
    public class PassportContext
    {
    	public SecurityPermissions MyProperty { get; set; }
    }
    
    [TestMethod]
    public void YourUnitTest()
    {
    
    using (var c = new UnityContainer())
    {
    	var sp = new SecurityPermissions() { Add = true, Change = true };
    
    	c.RegisterType(typeof(PassportContext), new InjectionProperty("MyProperty", sp));
    	var pc = c.Resolve<PassportContext>();
