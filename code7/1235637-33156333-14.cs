    public class IconUtils
    {
        // copy DLL declarations above here...
        // ...
        // and copy again the XML summary here.
    	public static bool DestroyIconH(IntPtr iconHandle)
    	{
    		return DestroyIcon(iconHandle);
    	}
        /// <summary>
        /// Gets the Pointer to the (stock) Icon associated to the specified ID.
        /// </summary>
        /// <param name="StockIconID">Icon ID among the defined Stock ones.</param>
        /// <returns>The Pointer to the retrieved Icon. If no Icon were found, an empty Pointer is returned.</returns>
        private static IntPtr GetShellIconPointer(SHSTOCKICONID StockIconID, SHGSI IconOptions)
        {
	        SHSTOCKICONINFO StkIconInfo = new SHSTOCKICONINFO();
	        StkIconInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(typeof(SHSTOCKICONINFO)));
	        if (SHGetStockIconInfo(StockIconID, IconOptions, StkIconInfo) == 0) {
		        return StkIconInfo.hIcon;
	        }
	        return IntPtr.Zero;
        }
        /// <summary>
        /// Gets the (stock) Icon associated to the specified ID.
        /// </summary>
        /// <param name="StockIconID">Icon ID among the defined Stock ones.</param>
        /// <returns>The (stock) Icon. If no Icon were found, Null is returned.</returns>
        /// <remarks>WARNING ! Caller is responsible of calling Dispose() on the returned Icon.</remarks>
        public static Icon GetSystemIcon(SHSTOCKICONID stockIconID, SHGSI iconOptions)
        {
        	IntPtr iconPointer = GetShellIconPointer(stockIconID, iconOptions);
        	if (iconPointer != IntPtr.Zero) {
        		Icon actualIcon = Icon.FromHandle(iconPointer);
        		Icon iconCopy = (System.Drawing.Icon)actualIcon.Clone();
        		actualIcon.Dispose();
        		DestroyIcon(iconPointer);
                /*
                    Honestly, I'm unsure of what I'm doing here :-(
                    If I get rid of either actualIcon or iconCopy, 
                    and don't make a copy of it, I get a 0x0 Icon.
                    If I don't call DestroyIcon(h), I get a memory leak.
                    I highly doubt a memory leak won't occur even with the trick above,
                    but heh! >:-D honestly I don't care since 
                    everything related to Icon retrieval in Windows 
                    appears to me a very bad design pattern in the first place.
                */
        		return iconCopy;
        	} else {
        		return null;
        	}
        }
    }
