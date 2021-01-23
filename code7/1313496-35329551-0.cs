	private void doVerify(object sender, DoWorkEventArgs args)
	{
		CData[] items = (CData[])args.Argument;
		VerificationResult verificationResult = new VerificationResult();
		for (int i = 0; i < items.Length || verificationResult.score > 0; i++)
		{
			verificationResult.score = _engine.Verify(items[i].EngineUser, 20000, out verificationResult.engineStatus);
		}
		args.Result = verificationResult;
	}
