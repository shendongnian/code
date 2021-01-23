    [AllowAnonymous]
    public void ChargeBeeWebhook()
    {
        // type variable will be "unsubscribe"
        string type = Request.Form["type"];
        // action variable will be "unsub"
        string action = Request.Form["data[action]"];
        // reason variable will be "manual"
        string reason = Request.Form["data[reason]"];
        // ...
        // ...
        // ... do the same with the rest of the posted variables
        // ...
        // sync the posted data above with your database
        // ...
        // ...
    }
