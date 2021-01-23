    public virtual void RemoveAt(int index) {
                    if (index < 0 || index >= owner.columnHeaders.Length)
                        throw new ArgumentOutOfRangeException("index", SR.GetString(SR.InvalidArgument, "index", (index).ToString(CultureInfo.CurrentCulture)));
     
                    int w = owner.columnHeaders[index].Width; // Update width before detaching from ListView
     
                    // in Tile view our ListView uses the column header collection to update the Tile Information
                    if (owner.IsHandleCreated && this.owner.View != View.Tile) {
                     
              !!! important: 
                    int retval = unchecked( (int) (long)owner.SendMessage(NativeMethods.LVM_DELETECOLUMN, index, 0));
                                              ^-----^----> quite strange...
           
            _________________________________________________
            |  Here it is (probably):    
            |            if (0 == retval)
            |                throw new ArgumentException(SR.GetString(SR.InvalidArgument,
            |                                                          "index",
            |                                                          (index).ToString(CultureInfo.CurrentCulture)));
                    }
