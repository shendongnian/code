    public async Task SendAsync(IdentityMessage message)
            {
    
                // Plug in your email service here to send an email.
                var mailMessage = new MailMessage("Email here",
                    message.Destination,
                    message.Subject,
                    message.Body
                    );
    
                var client = new SmtpClient();
                await client.SendMailAsync(mailMessage);
            }
