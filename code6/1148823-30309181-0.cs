    var xml = XElement.Parse(GetXmlToProcess());
    var Controllers = xml.Elements("Controllers").Select(x=> x)
						  .Elements("Controller").Select(x=> 
						  {
						  	  return GetControllerFromXml(x);
						  });
					   
	public Controller GetControllerFromXml( XElement elem)
	{
		var controller  = new Controller();
		controller.Name = elem.Elements("Name").First().Value;
		controller.CntrlType = elem.Elements("CntrlType").First().Value;
		controller.IPAddress = elem.Elements("IPAddress").First().Value;
		controller.NetworkId = elem.Elements("NetworkId").First().Value;
		controller.DeviceId = elem.Elements("DeviceId").First().Value;
		var io = elem.Elements("IO");
		if (io != null)
		{
			controller.IO.Inputs.AddRange( io.Elements("Inputs")
											.Elements("Input")
											.Select(v=> new Input
													{
														Name =  v.Elements("Name").First().Value,
														Channel =  v.Elements("Channel").First().Value,
														Value =  v.Elements("Value").First().Value
													})
										);
			controller.IO.Outputs.AddRange( io.Elements("Outputs")
											.Elements("Output")
											.Select(v=> new Output
													{
														Name =  v.Elements("Name").First().Value,
														Channel =  v.Elements("Channel").First().Value,
														Value =  v.Elements("Value").First().Value
													})
										);
		}
		var childrenController =  elem.Elements("ChildControllers");
		if(childrenController != null)
		{
			foreach(var child in childrenController.Elements("ChildController"))
			{
				var childController =  new ChildController();
				controller.ChildControllers.Add(childController);
				childController.Name = child.Elements("Name").First().Value;
				childController.CntrlType = child.Elements("CntrlType").First().Value;
				childController.Id = child.Elements("Id").First().Value;
				childController.Port = child.Elements("Port").First().Value;
				var cio = child.Elements("IO");
				if (cio != null)
				{
					childController.IO.Inputs.AddRange( cio.Elements("Inputs")
											.Elements("Input")
											.Select(v=> new Input
													{
														Name =  v.Elements("Name").First().Value,
														Channel =  v.Elements("Channel").First().Value,
														Value =  v.Elements("Value").First().Value
													})
										);
					childController.IO.Outputs.AddRange( cio.Elements("Outputs")
											.Elements("Output")
											.Select(v=> new Output
													{
														Name =  v.Elements("Name").First().Value,
														Channel =  v.Elements("Channel").First().Value,
														Value =  v.Elements("Value").First().Value
													})
										);
		}
				
			}
		}
	
		return controller;
	}
	// Define other methods and classes here
	public class Controller
	{
		public string Name{get;set;}
		public string CntrlType{get; set;}
		public string IPAddress{get; set;}
		public string NetworkId{get; set;}
		public string DeviceId{get; set;}
		public IO IO {get;set;}
		public List<ChildController> ChildControllers{get; set;}
		
		public Controller()
		{
			IO  = new IO();
			ChildControllers = new List<ChildController>();
		}
	}
	
	public class ChildController
	{
		public string Name{get;set;}
		public string CntrlType{get; set;}
		public string Id{get; set;}
		public string Port{get; set;}
		public IO IO {get;set;}
		
		public ChildController()
		{
			IO  = new IO();
		}
	}
	
	public class IO
	{
		public List<Input> Inputs {get; set;} 
		public List<Output> Outputs  {get; set;} 
		public IO()
		{
			Inputs = new List<Input>();
			Outputs = new List<Output>();
		}
	}
	public class Input
	{
		public string Name{get;set;}
		public string Channel{get; set;}
		public string Value{get; set;}
	}
	
	public class Output
	{
		public string Name{get;set;}
		public string Channel{get; set;}
		public string Value{get; set;}
	}
