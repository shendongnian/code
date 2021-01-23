    public static class ExcelExtensionMethods
    {
    [DllImport("ole32.dll")]
    static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);
    /// <summary>
    /// WORKBOOK EXTENSION METHOD
    /// Checks to see if the Workbook is embeeded inside of 
    /// another ActiveX Document type, sy=uch as Word or Excel.
    /// </summary>
    /// <param name="PobjWb"></param>
    /// <returns></returns>
    public static bool IsEmbedded(this Excel.Workbook PobjWb)
    {
        if (PobjWb.Path == null || PobjWb.Path.Length == 0)
        {
            try
            {
                // requires using Microsoft.VisualStudio.OLE.Interop;
                // and you have to manually add this to reference from here:
                // C:\Program Files (x86)\Microsoft Visual Studio 10.0\Common7\IDE\PrivateAssemblies\Microsoft.VisualStudio.OLE.Interop.dll
                IOleObject LobjOleObject = ((object)PobjWb) as IOleObject;
                IOleClientSite LobjPpClientSite;
                // get the client site
                LobjOleObject.GetClientSite(out LobjPpClientSite);
                // if there is one - we are embedded
                if (LobjPpClientSite != null)
                {
                    return true;
                }
                else
                {
                    // not embedded
                    return false;
                }
            }
            catch (Exception ex)
            {
                // exception
                Debug.Print(ex.ToString());
                return false;
            }
            finally { }
        }
        else
        {
            // not embedded
            return false;
        }
    }
    /// <summary>
    /// WORKBOOK EXTENSION METHOD
    /// This method return the name of the class that we
    /// are embedded inside of.
    /// If we are not embedded it return null.
    /// If there is any exception it return null.
    /// If the container cannot be accessed it returns UNKNOWN.
    /// </summary>
    /// <param name="PobjWb"></param>
    /// <returns></returns>
    public static string EmbedClassName(this Excel.Workbook PobjWb)
    {
        try
        {
            IOleObject LobjOleObject = ((object)PobjWb) as IOleObject;
            IOleClientSite LobjPpClientSite;
            // get the client site
            LobjOleObject.GetClientSite(out LobjPpClientSite);
            if (LobjPpClientSite != null)
            {
                IOleContainer LobjPpContainer;
                LobjPpClientSite.GetContainer(out LobjPpContainer);
                if (LobjPpContainer != null)
                {
                    return LobjPpContainer.GetType().Name;
                }
                else
                {
                    // something wrong - container is not valid
                    return "UNKNOWN";
                }
            }
            else
            {
                // not embedded
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.ToString());
            return null; // failed
        }
    }
    /// <summary>
    /// WORKBOOK EXTENSION METHOD
    /// Get the full path to the file that the workbook is embedded 
    /// inside of. 
    /// If we are not embeeded then this will return null.
    /// If we are embedded but there are issues with the container
    /// or an exception occurs, it will return null.
    /// Otherwise we get the full path and filename.
    /// </summary>
    /// <param name="PobjWb"></param>
    /// <returns></returns>
    public static string EmbedMoniker(this Excel.Workbook PobjWb)
    {
        try
        {
            IOleObject LobjOleObject = ((object)PobjWb) as IOleObject;
            IOleClientSite LobjPpClientSite;
            // get the client site
            LobjOleObject.GetClientSite(out LobjPpClientSite);
            if (LobjPpClientSite != null)
            {
                IOleContainer LobjPpContainer;
                LobjPpClientSite.GetContainer(out LobjPpContainer);
                if (LobjPpContainer != null)
                {
                    // get the moniker
                    IMoniker LobjMoniker;
                    LobjPpClientSite.GetMoniker((uint)OLEGETMONIKER.OLEGETMONIKER_FORCEASSIGN,
                                                (uint)OLEWHICHMK.OLEWHICHMK_OBJFULL,
                                                out LobjMoniker);
                    if (LobjMoniker != null)
                    {
                        // now pull the moniker display name
                        // this will be in the form of PATH!Context
                        string LstrDisplayName;
                        IBindCtx LobjCtx = null;
                        CreateBindCtx(0, out LobjCtx); // required (imported function)
                        LobjMoniker.GetDisplayName(LobjCtx, null, out LstrDisplayName);
                        // remove context is exists
                        if (LstrDisplayName.Contains("!"))
                        {
                            string[] LobjMonikerArray = LstrDisplayName.Split('!');
                            // return the first part - which should be the path
                            return LobjMonikerArray[0];
                        }
                        else
                        {
                            // return full display name
                            return LstrDisplayName;
                        }
                    }
                    else
                    {
                        // no moniker value
                        return null;
                    }
                }
                else
                {
                    // something wrong - container is not valid
                    return null;
                }
            }
            else
            {
                // not embedded
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.Print(ex.ToString());
            return null; // failed
        }
    }
    }
