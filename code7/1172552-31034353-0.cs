	public class Applicant
	{
		public string LastName { get; set;}
	}
	
	public void Process(XmlElement application, Applicant applicant)
	{
		var selectors = new[] {
			new { 
                      Setter = new Action<Applicant, string>((t,v) => t.LastName = v), 
                      XPath = "GivenName/LastName"
                }
		};
		
		foreach(var selector in selectors)
		{
			var node = application.SelectSingleNode("AIndividual[@Type='PrimaryApplicant']/" + selector.XPath) ??
							application.SelectSingleNode("AIndividual[@Type='CoApplicant']/" + selector.XPath);
						
			selector.Setter(applicant, node == null ? "-" : node.Value);
		}
	}
