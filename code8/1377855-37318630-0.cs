    void sendEmail(string toEmail, string emailSubject, string emailBody)
    {
        emailSubject = System.Uri.EscapeUriString(emailSubject);
        emailBody = System.Uri.EscapeUriString(emailSubject);
        Application.OpenURL("mailto:" + toEmail + "?subject=" + emailSubject + "&body=" + emailBody);
    }
