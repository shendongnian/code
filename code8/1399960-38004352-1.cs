    public static class OleDbParameterCollectionExtensions
    {
        // <summary>
        // Calls Clear() on the OleDbParameterCollection and performs
        // a check to make sure it succeeds.  If it does not succeed
        // an exception will be thrown.
        // </summary>
        public static void SafeClear(this OleDbParameterCollection @this)
        {
            // Call the method.
            @this.Clear();
            // Do the sanity check
            if (@this.Count != 0)
            {
                throw new Exception(@"OleDbParameterCollection.Clear() failed.");
            }
        }
    }
    // Usage:
    OleDbParameterCollection collection = /* ... */;
    collection.SafeClear();
