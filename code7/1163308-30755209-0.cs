	static void Main()
	{
		var root = XElement.Parse(xmlToParse);
	
		var orderedRoundElements= root.Elements("round")
									.Select(element=>{
													var actions = element.Elements("action")
																		.OrderBy(elem=> (int)elem.Attribute("no"))
																		.ToList();
													foreach (var act in actions)
													{
														act.Remove();
													}
													element.Add(actions);
													return element;
										}).ToList();
	
			Console.WriteLine(root.ToString());
	}
