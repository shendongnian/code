    private IEnumerator SignUpHandler()
    {
        bool success = true;
        string error;
        
        Task signup = user.SignUpAsync();//.ContinueWith(t =>
        while (!signup.IsCompleted) yield return null;
        if (signup.IsFaulted || signup.IsCanceled)
        {
            //Debug.Log("Error " + signup.Exception.Message);
            error = "Failed to sign up Parse User. Reason: " + signup.Exception.Message;
            success = false;
        }
        else
        {
            Debug.Log("Done");
            Application.LoadLevel("ExampleScene");
        }
        
    }
