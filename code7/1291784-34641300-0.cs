        public static void ClickonHyperlink(string divProp, string hyperlinkProp) 
    { 
            var _div = new HtmlDiv(browser);
            _div.SearchProperties.Add("ID", divProp);
            var _hyper = new HtmlHyperlink(_div);
            _hyper.SearchProperties.Add("ID", hyperlinkProp);
            _hyper.WaitForControlReady();
            Mouse.Click(_hyper);
     }  
        FunctionLib.ClickonHyperlink("loadingOverlay", "hyperlinkClick");
