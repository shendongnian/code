        var success = await Windows.System.Launcher.LaunchUriAsync(new System.Uri("alsdkcs:MainPage?id="+5)); 
        if (success){
           // URI launched
        }
        else{
          // URI launch failed
        }
      where "alsdkcs" is protocol name.
