    XDocument doc = XDocument.Load(new StringReader(testString));
	var arrayList = doc.Descendants("Role")
					.Select(a => new Role{
						Name = a.Attribute("name").Value,
						Permissions = a.Descendants("PermissionName").Select(x=> x.Value).ToList()
					}).ToArray();
    public class Role{
	public string Name{get;set;}
	public List<string> Permissions{get;set;}
    }
