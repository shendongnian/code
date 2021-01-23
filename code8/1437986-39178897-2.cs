    public static void ReadDateTimeData(out IntPtr unmanagedArray, out int length)
    {
        // Get the DateTimeArray
        DateTime[] dateTimeArray = GetDateTimeArray();
        length = dateTimeArray.Length;
        // Convert to double[]
        double[] oaDateArray = new double[length];
        for (int i = 0; i < length; i++)
            oaDateArray[i] = dateTimeArray[i].ToOADate();
        unmanagedArray = Marshal.AllocHGlobal(length * Marshal.SizeOf(typeof(double)));
        Marshal.Copy(oaDateArray, 0, unmanagedArray, length);
    }
