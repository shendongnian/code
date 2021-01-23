    ticket.Attachments = (from ta in context.TicketAttachments
                                              join a in context.Attachments on ta.AttachmentId equals a.Id
                                              join at in context.AttachmentTypes on a.TypeId equals at.Id
                                              where ta.TicketId == ticket.Id
                                              select new Domain.Model.Tickets.Attachment
                                              {
                                                  Id = a.Id,
                                                  // Load all fields
                                                  Data = a.Data,
                                                  Size = a.Size,
                                                  Name = a.Name,
                                                  AttachmentType = new Domain.Model.Tickets.AttachmentType()
                                                  {
                                                      ContentType = at.ContentType,
                                                      FileExtension = at.FileExtension
                                                  }
                                              }).ToList();
                      
                        foreach (var attachment in ticket.Attachments)
                        {
                            Stream stream = new MemoryStream(attachment.Data);
                            MongoGridFSFileInfo mongoGridFsFileInfo = mongoDbContext.MongoGridFs.Upload(stream, attachment.Name);
                            attachment.GridFsObjectId = mongoGridFsFileInfo.Id.AsObjectId;
                        }
