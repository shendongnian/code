	internal static class NativeMethods
	{
		[DllImport("dwmapi.dll", EntryPoint="#127")]
		internal static extern void DwmGetColorizationParameters(ref DWMCOLORIZATIONcolors colors);
	}
	public struct DWMCOLORIZATIONcolors
	{
		public uint ColorizationColor, 
			ColorizationAfterglow, 
			ColorizationColorBalance, 
			ColorizationAfterglowBalance, 
			ColorizationBlurBalance, 
			ColorizationGlassReflectionIntensity, 
			ColorizationOpaqueBlend;
	}
	private static Color GetWindowColorizationColor(bool opaque)
	{
		var colors = NativeMethods.DwmGetColorizationParameters();
		return Color.FromArgb((byte)(opaque ? 255 : colors.ColorizationColor >> 24),
			(byte)(colors.ColorizationColor >> 16), 
			(byte)(colors.ColorizationColor >> 8), 
			(byte)colors.ColorizationColor);
	}
