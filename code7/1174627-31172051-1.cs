    /// <summary>
    /// Gets the profile's XML specification. Key is unencrypted.
    /// </summary>
    /// <param name="profileName">The name of the profile.</param>
    /// <returns>The XML document.</returns>
    public string GetProfileXmlUnencrypted(string profileName)
    {
        IntPtr profileXmlPtr;
        Wlan.WlanProfileFlags flags = Wlan.WlanProfileFlags.GetPlaintextKey;
        Wlan.WlanAccess access;
        Wlan.ThrowIfError(
            Wlan.WlanGetProfile(client.clientHandle, info.interfaceGuid, profileName, IntPtr.Zero, out profileXmlPtr, out flags, out access));
        try
        {
            return Marshal.PtrToStringUni(profileXmlPtr);
        }
        finally
        {
            Wlan.WlanFreeMemory(profileXmlPtr);
        }
    }
