    using Xamarin.Forms;
    ...
    if(Device.OS == TargetPlatform.Android)
        Debug.WriteLine("I'm on Android");
    else if(Device.OS == TargetPlatform.iOS)
        Debug.WriteLine("This is iOS");
