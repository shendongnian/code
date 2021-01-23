      /// <summary>
      /// Initiates sending an e-mail over the default e-mail application by 
      /// opening a mailto URL with the given data.
      /// </summary>
      public static async void SendEmailOverMailTo(string recipient, string cc, 
         string bcc, string subject, string body)
      {
         if (String.IsNullOrEmpty(recipient))
         {
            throw new ArgumentException("recipient must not be null or emtpy");
         }
         if (String.IsNullOrEmpty(subject))
         {
            throw new ArgumentException("subject must not be null or emtpy");
         }
         if (String.IsNullOrEmpty(body))
         {
            throw new ArgumentException("body must not be null or emtpy");
         }
         // Encode subject and body of the email so that it at least largely 
         // corresponds to the mailto protocol (that expects a percent encoding 
         // for certain special characters)
         string encodedSubject = WebUtility.UrlEncode(subject).Replace("+", " ");
         string encodedBody = WebUtility.UrlEncode(body).Replace("+", " ");
         // Create a mailto URI
         Uri mailtoUri = new Uri("mailto:" + recipient + "?subject=" +
            encodedSubject +
            (String.IsNullOrEmpty(cc) == false ? "&cc=" + cc : null) +
            (String.IsNullOrEmpty(bcc) == false ? "&bcc=" + bcc : null) +
            "&body=" + encodedBody);
         // Execute the default application for the mailto protocol
         await Launcher.LaunchUriAsync(mailtoUri);
      }
