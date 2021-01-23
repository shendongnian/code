    class MySmtpClient : SmtpClient
    {
        public MySmtpClient ()
        {
        }
    
        /// <summary>
        /// Get the envelope identifier to be used with delivery status notifications.
        /// </summary>
        /// <remarks>
        /// <para>The envelope identifier, if non-empty, is useful in determining which message
        /// a delivery status notification was issued for.</para>
        /// <para>The envelope identifier should be unique and may be up to 100 characters in
        /// length, but must consist only of printable ASCII characters and no white space.</para>
        /// <para>For more information, see rfc3461, section 4.4.</para>
        /// </remarks>
        /// <returns>The envelope identifier.</returns>
        /// <param name="message">The message.</param>
        protected override string GetEnvelopeId (MimeMessage message)
        {
            // The Message-Id header is probably the easiest way to go...
            return message.MessageId;
        }
    
        /// <summary>
        /// Get the types of delivery status notification desired for the specified recipient mailbox.
        /// </summary>
        /// <remarks>
        /// Gets the types of delivery status notification desired for the specified recipient mailbox.
        /// </remarks>
        /// <returns>The desired delivery status notification type.</returns>
        /// <param name="message">The message being sent.</param>
        /// <param name="mailbox">The mailbox.</param>
        protected override DeliveryStatusNotification? GetDeliveryStatusNotifications (MimeMessage message, MailboxAddress mailbox)
        {
            // Since you want to know whether the message got delivered or not,
            // you'll probably want to get notifications for Success and Failure.
            return DeliveryStatusNotification.Success | DeliveryStatusNotification.Failure;
        }
    }
