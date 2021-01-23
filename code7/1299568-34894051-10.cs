    private void ActionConnectionResultReceived(GooglePlayConnectionResult result)
    {
        if (result.IsSuccess)
        {
            Debug.Log("Connected!");
            switch (gCaller){
                case "alpha":
                  alphaClicked();
                  break;
                case "beta":
                  betaClicked();
                  break;
                default:
                  break;
            }
        }
        else
        {
            Debug.Log("Cnnection failed with code: " + result.code.ToString());
        }
    }
