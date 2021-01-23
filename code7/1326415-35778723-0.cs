        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("pass", password);
        if (!string.IsNullOrEmpty(arg))
            form.AddField(arg, "please");
        WWW www = new WWW(URL, form);
        // Wait until the request has been sent
        yield return www;
        if (www.isDone)
        {
            Debug.Log("WWW text = " + www.text);
            if (callback(www.text))
            {
                // we are logged
            }
            else
            {
                // we arn't
            }
