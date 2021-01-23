	public class MyReturnObject {
		public MyReturnObject(int currentAddress, int classAddress, string className) {
			// ...
		}
	}
	public MyReturnObject ParseStuff(int? classAddress, string className, int currentAddress) {
		if(classAddress.HasValue && className != null) {
			className = className.Trim();
			if(!String.IsNullOrEmpty(className)) {
				var r = System.Text.RegularExpressions.Regex.Match(className, @"[^\a\d_.]")?.Index;
				
				if(!r.HasValue || r.Value >= 5) {
					return new MyReturnObject(currentAddress, classAddress.Value, className);
				}
			}
		}
		
		return null;
	}
