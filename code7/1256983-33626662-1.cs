    private void Initialize()
		{
			EndpointAddress ea = new EndpointAddress("http://x.x.x.x:9001/CalcService");
			BasicHttpBinding bhttpb = new BasicHttpBinding();
			bhttpb.Security.Mode = BasicHttpSecurityMode.None;
			objCalcClient2 = new CalcServiceClient(bhttpb, ea);
		}
		public async void DoStuff()
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
			Debug.WriteLine(Text);
		}
