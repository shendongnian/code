     //From Activity 1
    private async void NavigateButton_OnClicked(object o, EventArgs e)
    {  
        var objectString = Newtonsoft.Json.JsonConvert.SerializeObject(yourClass);
        var activity = new Intent(this, typeof(activityName));
        activity.PutExtra("yourObjectName", objectString );
        StartActivity(activity);
    }
