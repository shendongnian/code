        public AutomationElement GetItem(int row, int column)
        {
            try
            {
                UIAutomationClient.IUIAutomationElement element;
                int hr = _pattern.GetItem(row, column, out element);
                if (hr != 0)
                    throw Marshal.GetExceptionForHR(hr); // note this uses COM's EXCEPINFO if any
                return AutomationElement.Wrap(element).GetUpdatedCache(CacheRequest.Current);
            }
            catch (System.Runtime.InteropServices.COMException e)
            {
                Exception newEx; if (Utility.ConvertException(e, out newEx)) { throw newEx; } else { throw; }
            }
        }
