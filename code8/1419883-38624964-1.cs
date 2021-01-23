    internal static IDialog<ProfileForm> MakeRootDialog()
    {
        return Chain.From(() => FormDialog.FromForm(ProfileForm.BuildForm));
    }
    public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
    {
        // Detect if this is a Message activity
        if (activity.Type == ActivityTypes.Message)
        {
            // Call our FormFlow by calling MakeRootDialog
            await Conversation.SendAsync(activity, MakeRootDialog);
        }
        else
        {
            // This was not a Message activity
            HandleSystemMessage(activity);
        }
        // Return response
        var response = Request.CreateResponse(HttpStatusCode.OK);
        return response;            
    }
