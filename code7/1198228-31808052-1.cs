    public void ShowToastWithCloudService(bool useCustomSound, bool useWavFormat, bool doSilentToast)
    {
        StringBuilder toastMessage = new StringBuilder();
        toastMessage.Append("<?xml version=\"1.0\" encoding=\"utf-8\"?><wp:Notification xmlns:wp=\"WPNotification\"><wp:Toast>");
        toastMessage.Append("<wp:Text1>Toast Title</wp:Text1>");
        toastMessage.Append("<wp:Text2>Toast Content</wp:Text2>");
        if ((IsTargetedVersion) && (useCustomSound))
        {
            if (useWavFormat)
            {
                toastMessage.Append("<wp:Sound>MyToastSound.wav</wp:Sound>");
            }
            else
            {
                toastMessage.Append("<wp:Sound>MyToastSound.mp3</wp:Sound>");
            }
        }
        else if ((IsTargetedVersion) && (doSilentToast))
        {
            toastMessage.Append("<wp:Sound Silent=\"true\"/>");
        }
        toastMessage.Append("</wp:Toast></wp:Notification>");
    }
