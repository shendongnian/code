        public class Entity{
	        public string Year {get;set;}
	        public string Make {get;set;}
	        public string Model {get;set;}
	        public string Color {get;set;}
	        public string ColorLower {get;set;}
	        public string Style {get;set;}
	        public string Description{
		        get {
			        string format = "{0} ";
			        StringBuilder sb = new StringBuilder();
			        sb.Append(!string.IsNullOrEmpty(Year) && !string.IsNullOrEmpty(Year.Trim()) 
			            ? string.Format(format, Year.Trim()) : string.Empty);
			        sb.Append(!string.IsNullOrEmpty(Make) && !string.IsNullOrEmpty(Make.Trim()) 
				        ? string.Format(format, Make.Trim()) : string.Empty);
			        sb.Append(!string.IsNullOrEmpty(Model) && !string.IsNullOrEmpty(Model.Trim()) 
				        ? string.Format(format, Model.Trim()) : string.Empty);
			        sb.Append(!string.IsNullOrEmpty(Color) && !string.IsNullOrEmpty(Color.Trim()) 
				        ? string.Format(format, Color.Trim()) : string.Empty);
			        sb.Append(!string.IsNullOrEmpty(ColorLower) && !string.IsNullOrEmpty(ColorLower.Trim()) 
				        ? string.Format(format, ColorLower.Trim()) : string.Empty);
			        sb.Append(!string.IsNullOrEmpty(Style) && !string.IsNullOrEmpty(Style.Trim()) 
				        ? string.Format(format.Trim(), Style.Trim()) : string.Empty);
			        return sb.ToString();
		        }
		    }
		}
		static void Main()
		{
			var e1 = new Entity{Year="Y",Make="M",Model="Md",
				Color="C",ColorLower="CL",Style="S"};
			Console.WriteLine(e1.Description); // 'Y M Md C CL S'
		}
