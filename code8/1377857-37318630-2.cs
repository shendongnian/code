    private static void SendMail(string subject, string body, bool useHTML)
    {
        using (var intentClass = new AndroidJavaClass("android.content.Intent"))
        {
            // intent = new Intent(Intent.ACTION_SEND);
            using (var intentObject = new AndroidJavaObject("android.content.Intent", intentClass.GetStatic<string>("ACTION_SEND")))
            {
                // Setting text type
                if (useHTML)
                    // intent.setType("text/html");
                    intentObject.Call<AndroidJavaObject>("setType", "text/html");
                else
                    // intent.setType("message/rfc822");
                    intentObject.Call<AndroidJavaObject>("setType", "message/rfc822");
                // intent.putExtra(Intent.EXTRA_SUBJECT, emailSubject);
                intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_SUBJECT"), subject);
                // Setting emailBody
                if (useHTML)
                {
                    // intent.putExtra(Intent.EXTRA_TEXT, Html.fromHtml(emailBody));
                    using (var html = new AndroidJavaClass("android.text.Html"))
                    {
                        var htmlBody = html.CallStatic<AndroidJavaObject>("fromHtml", body);
                        intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), htmlBody);
                    }
                }
                else
                {
                    intentObject.Call<AndroidJavaObject>("putExtra", intentClass.GetStatic<string>("EXTRA_TEXT"), body);
                }
                using (var unity = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    using (var currentActivity = unity.GetStatic<AndroidJavaObject>("currentActivity"))
                    {
                        currentActivity.Call("startActivity", intentObject);
                    }
                }
            }
        }
    }
