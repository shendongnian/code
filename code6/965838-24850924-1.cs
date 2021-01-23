        private void RemoveReference(object o)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(o);
            }
            catch
            { }
            finally
            {
                o = null;
            }
        }
