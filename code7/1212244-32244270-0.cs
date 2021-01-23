          These are some method you can use and set width and height of the window.
            public static Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
            public static double GetDIPIndependent(double value, double DPI)
            {
                value = value * (graphics.DpiX / DPI);
                return value;
            }
            public static double GetDIPDependent(double value, double DPI)
            {
                value = value * (DPI / graphics.DpiX);
                return value;
            }
            public static double GetDIPIndependent(double value)
            {
                value = value * (graphics.DpiX / 96.0);
                return value;
            }
            
            public static double GetDIPDependent(double value)
            {
                value = value * (96.0 / graphics.DpiX);
                return value;
            }
           
    Example:-
    if DPI InDependent
    this.Width = GetDIPIndependent(this.Width)
    this.Height = GetDIPIndependent(this.Height)
    
    if DPI Dependent
    this.Width = GetDIPDependent(this.Width)
    this.Height = GetDIPDependent(this.Height)
