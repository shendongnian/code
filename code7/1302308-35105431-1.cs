    async private void webView_ScriptNotify(object sender, NotifyEventArgs e)
        {
           if (e.Value.ToLower().Equals("gety"))
            {
                string sValue = JsonConvert.SerializeObject(lstY) 
                 //lstY is list of Y values in array;
                List<string> lstValue = new List<string>() { sValue };
                await webGraph.InvokeScriptAsync("getYValue", lstValue);
            }
        }
