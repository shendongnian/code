    void UserAction(string input) {
        try {
            serviceB.RespondToAction(input);
        }
        catch (FaultException e) {
           if (e.InnerException is CustomException) {
              DisplayMessageToUser(ResolveExceptionMessage((CustomException)e.InnerException));
           }
        }
        catch (CustomException e) {
              DisplayMessageToUser(ResolveExceptionMessage(e));         
        }
    }
