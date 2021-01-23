    internal static class NativeMethods
    {
        [DllImport("dwmapi.dll", EntryPoint="#127")]
        internal static extern void DwmGetColorizationParameters(ref DWMCOLORIZATIONPARAMS params);
    }
    public struct DWMCOLORIZATIONPARAMS
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
        var params = NativeMethods.DwmGetColorizationParameters();
        return Color.FromArgb((byte)(opaque ? 255 : params.ColorizationColor >> 24),
            (byte)(params.ColorizationColor >> 16), 
            (byte)(params.ColorizationColor >> 8), 
            (byte)params.ColorizationColor);
    }
