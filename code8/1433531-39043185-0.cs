    class SdCardOperation : IDisposable
    {
        /// <summary>
        /// Runs a action on the SdCardOperation only if there is a SD card available.
        /// </summary>
        /// <param name="action">The action to perform</param>
        /// <returns>True if the action was run, false if it was not.</returns>
        public static bool RunOnSdCard(Action<SdCardOperation> action)
        {
            using (var operation = new SdCardOperation())
            {
                if (operation.NoSdcard)
                    return false;
            
                action(operation);
                return true;
            }
        }
        // Your other code here.
    }
