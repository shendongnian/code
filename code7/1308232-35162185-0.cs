        private dynamic GetDOM(WebBrowser wb)
        {
            dynamic document = null;
            System.Threading.Thread.Sleep(500);
            while (document == null)
            {
                Dispatcher.Invoke(() => document = wb.Document);
                System.Threading.Thread.Sleep(100);
            }
            return document;
        }
