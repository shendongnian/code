    lbDatabase.Invoke((MethodInvoker)(() => {
        VerificationResult verificationResult = new VerificationResult();
        for (int i = 0; i < lbDatabase.Items.Count || verificationResult.score > 0; i++)
        {
            lbDatabase.SelectedItem = i;  
            verificationResult.score = _engine.Verify(((CData)lbDatabase.SelectedItem).EngineUser, 20000, out verificationResult.engineStatus);
        }
        args.Result = verificationResult;
    })); 
