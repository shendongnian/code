     var task = _emailService.Send(new List<string> { @event.ContactEmail }, subject, body,
                        new List<Attachment>
                            {
                                new Attachment(new MemoryStream(bytes), report.FileName, "application/pdf")
                            });
    
                    if (task != null)
                    {
                        task.Wait();
                    }
