    /// <summary> Allows changing the gamma of the displays. </summary>
    public static class GammaChanger
    {
      /// <summary>
      ///  Retrieves the current gamma ramp data so that it can be restored later.
      /// </summary>
      /// <param name="gamma"> [out] The current gamma. </param>
      /// <returns> true if it succeeds, false if it fails. </returns>
      public static bool GetCurrentGamma(out GammaRampRgbData gamma)
      {
        gamma = GammaRampRgbData.Create();
        return GetDeviceGammaRamp(GetDC(IntPtr.Zero), ref gamma);
      }
    
      public static bool SetGamma(ref GammaRampRgbData gamma)
      {
        // Now set the value.
        return SetDeviceGammaRamp(GetDC(IntPtr.Zero), ref gamma);
      }
    
      public static bool SetBrightness(int gamma)
      {
        GammaRampRgbData data = new GammaRampRgbData
                                {
                                  Red = new ushort[256],
                                  Green = new ushort[256],
                                  Blue = new ushort[256]
                                };
    
        int wBrightness = gamma; // reduce the brightness
        for (int ik = 0; ik < 256; ik++)
        {
          int iArrayValue = ik * (wBrightness + 128);
          if (iArrayValue > 0xffff)
          {
            iArrayValue = 0xffff;
          }
          data.Red[ik] = (ushort)iArrayValue;
          data.Green[ik] = (ushort)iArrayValue;
          data.Blue[ik] = (ushort)iArrayValue;
        }
    
        return SetGamma(ref data);
      }
    
      [DllImport("gdi32.dll")]
      private static extern bool SetDeviceGammaRamp(IntPtr hdc, ref GammaRampRgbData gammaRgbArray);
    
      [DllImport("gdi32.dll")]
      private static extern bool GetDeviceGammaRamp(IntPtr hdc, ref GammaRampRgbData gammaRgbArray);
    
      [DllImport("user32.dll")]
      private static extern IntPtr GetDC(IntPtr hWnd);
    
      [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
      public struct GammaRampRgbData
      {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public UInt16[] Red;
    
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public UInt16[] Green;
    
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public UInt16[] Blue;
    
        /// <summary> Creates a new, initialized GammaRampRgbData object. </summary>
        /// <returns> A GammaRampRgbData. </returns>
        public static GammaRampRgbData Create()
        {
          return new GammaRampRgbData
                 {
                   Red = new ushort[256],
                   Green = new ushort[256],
                   Blue = new ushort[256]
                 };
        }
      }
    }
