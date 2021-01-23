    void InitializeServiceConnection()
	{
		EndpointAddress ea = new EndpointAddress("http://x.x.x.x:9001/CalcService");
		BasicHttpBinding bhttpb = new BasicHttpBinding()
		{
			Security = new BasicHttpSecurity()
			  {
			      Mode = BasicHttpSecurityMode.None,
				  Transport = new HttpTransportSecurity()
					{
						ProxyCredentialType = HttpProxyCredentialType.None,
						ClientCredentialType = HttpClientCredentialType.None
					}
			   },
			BypassProxyOnLocal = true
		};
		objCalcClient2 = new CalcServiceClient(bhttpb, ea);
	}
    	async void DoStuff()
		{
            dblResult = await Task.Run<double>(delegate { return objCalcClient2.Add(dblX, dblY); });
            WriteLine(string.Format("Calling Add >>  X : {0:F2}  Y : {1:F2} Result : {2:F2}", dblX, dblY, dblResult));
            dblResult = await Task.Run<double>(() => { return objCalcClient2.Subtract(dblX, dblY); });
            WriteLine(string.Format("Calling Sub >>  X : {0:F2}  Y : {1:F2} Result : {2:F2}", dblX, dblY, dblResult));
            dblResult = await Task.Run<double>(() => { return objCalcClient2.Multiply(dblX, dblY); });
            WriteLine(string.Format("Calling Mul >>  X : {0:F2}  Y : {1:F2} Result : {2:F2}", dblX, dblY, dblResult));
            dblResult = await Task.Run<double>(() => { return objCalcClient2.Divide(dblX, dblY); });
            WriteLine(string.Format("Calling Div >>  X : {0:F2}  Y : {1:F2} Result : {2:F2}", dblX, dblY, dblResult));
		}
		void WriteLine(string Text)
		{
			tvConsole.Text += System.Environment.NewLine + Text;
			tvConsole.Invalidate();
		}
