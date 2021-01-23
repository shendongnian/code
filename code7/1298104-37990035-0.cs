                try
                {
                    // Create a Web transport for sending email.
                    var transportWeb = new SendGrid.Web(credentials);
                    // Send the email.
                    if (transportWeb != null)
                    {
                        return transportWeb.DeliverAsync(myMessage);
                    }
                }
                catch (InvalidApiRequestException exception)
                {
                    if (exception.Errors != null)
                    {
                        foreach (var error in exception.Errors)
                        {
                            // Log error
                        }
                    } 
                }
