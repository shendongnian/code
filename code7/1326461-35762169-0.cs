    var oldAttachments = _context.ca_Attachments
                                 .Where(x => x.CaseId == getCase[0].Id && !x.isDeleted)
                                 .ToList();
    
    foreach (var oldAttachment in oldAttachments) 
    {
        data.ca_Attachments.Add(new ca_Attachment
        {
            AttachmentId = oldAttachment.attachmentId,
            creator = editor,
            LastUpdatedOn = _startTime,
        });
    }
