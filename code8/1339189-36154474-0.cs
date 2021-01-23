    string version;
    try
    {
      version = Marshal.PtrToStringAnsi(ClientGetVersion());
    }
    catch (Exception ex)
    {
      // Error handling omitted for clarity...
    }
