        private void doSomeWork()
        {
            // do work here -->
            if (someObject.InvokeRequired)
            {
                someObject.BeginInvoke((Action)delegate() { someObject.Property = someValue; });
            }
            else
            {
                someObject.Property = someValue;
            }
        }
