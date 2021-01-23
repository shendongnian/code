    class YahooClient : SmtpClient {
         Send(MailMessage message) { 
              /// Call base send and handle exception            
              try {
                 base.Send(message)
              }
              catch(ex as SmtpException) {
                  // Handle accordingly
              }
         }
    }
