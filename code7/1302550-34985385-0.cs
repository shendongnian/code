	public static class IosHelper
	{
		public static bool IsSimulator {
			get {
				return UIDevice.CurrentDevice.Model.EndsWith("Simulator") || UIDevice.CurrentDevice.Name.EndsWith("Simulator");
			}
		}
	}
