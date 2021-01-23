    switch (opRes.OpResult)
    {
        case OperationResult.Result.Succeeded :
            MessageBox.Show("Password coordination succeeded.");
            LoadUser();
            break;
        case OperationResult.Result.PartialSuccess :
            MessageBox.Show(String.Format("Password coordination partially succeeded: {0}{1}", Environment.NewLine, opRes.Notation));
            LoadUser();
            break;
        default :
            MessageBox.Show("Password coordination failed.");
            PswCoordFailDisplay coord1 = new PswCoordFailDisplay(opRes.Notation);
            coord1.Show();
            break;
    }
