        private void this_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopFiddler();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormClosing += this_FormClosing;
            ProxyHolder = new List<string>();
            ProxyHolder.Add("119.46.110.17:8080");
            ProxyHolder.Add("178.21.112.27:3128");
            ProxyHolder.Add("122.96.59.107:83");
            ProxyHolder.Add("136.0.16.217:3127");
            ProxyHolder.Add("198.52.199.152:7808");
            ProxyHolder.Add("122.96.59.107:82");
            StartFiddler();
            System.Threading.Thread.Sleep(500);
            for (var i = 0; i < ProxyHolder.Count; i++)
            {
                WhatIsMyIpThroughProxy(ProxyHolder[i]);
                Application.DoEvents();
                System.Threading.Thread.Sleep(500);
            }
            //WhatIsMyIpThroughProxy();
        }
        private Dictionary<int, string> WatinIEprocessHolder = new Dictionary<int, string>();
        private List<string> ProxyHolder = null;
        public void WhatIsMyIpThroughProxy(string ProxyIPandPort)
        {
            using (var browser = new IE(true))// we should not navigate now. Because we need process ids.
            {
                WindowHandleInfo ChildHandles = new WindowHandleInfo(browser.hWnd);
                foreach (var cHandle in ChildHandles.GetAllChildHandles())
                {
                    int pid = new WatiN.Core.Native.Windows.Window(cHandle).ProcessID;
                    if (WatinIEprocessHolder.ContainsKey(pid) == false)
                        WatinIEprocessHolder.Add(pid, ProxyIPandPort);
                }
                System.Text.StringBuilder processIDs = new System.Text.StringBuilder();
                foreach (var k in WatinIEprocessHolder.Keys)
                {
                    processIDs.Append(k.ToString() + ",");
                    //Debug.WriteLine(string.Format("{0}:{1}", k, WatinIEprocessHolder[k]));
                }
                //we got the process ids above. Navigate now.
                browser.GoTo("http://www.rentanadviser.com/en/common/tools.ashx?action=whatismyip");
                browser.WaitForComplete();
                WatinIEprocessHolder.Clear();
                System.Net.IPAddress ip;
                if (System.Net.IPAddress.TryParse(browser.Text, out ip))
                {
                    Debug.WriteLine(string.Format("Process Ids:{0}, Your IP address: {1}, Proxy:{2}", processIDs.ToString(), browser.Text, ProxyIPandPort));
                }
                else
                {
                    Debug.WriteLine(string.Format("Process Ids:{0}, Your IP address: {1}, Proxy:{2}", processIDs.ToString(), "Failed", ProxyIPandPort));
                }
            }
        }
        private void StartFiddler()
        {
            FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
            FiddlerApplication.Startup(8888, true, true, true);
        }
        private void StopFiddler()
        {
            FiddlerApplication.BeforeRequest -= FiddlerApplication_BeforeRequest;
            if (FiddlerApplication.IsStarted())
            {
                FiddlerApplication.Shutdown();
            }
        }
        
        private void FiddlerApplication_BeforeRequest(Session sess)
        {
            //Debug.WriteLine("FiddlerApplication_BeforeRequest: " + sess.LocalProcessID.ToString());
            if (WatinIEprocessHolder.ContainsKey(sess.LocalProcessID))
            {                
                //see http://stackoverflow.com/questions/14284256/how-to-manually-set-upstream-proxy-for-fiddler-core
                sess["X-OverrideGateway"] = WatinIEprocessHolder[sess.LocalProcessID];
            }
        }    
