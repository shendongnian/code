    if (getOldAttachment != null && getOldAttachment.Count > 0)
                {
                  for(var i = 0; i < getOldAttachment.Count; i++)
                  {
                      //this is how to populate the data from list
                      //sample only
                      ca_Attachment.AttachmentId = getOldAttachment[i].AttachmentId;
                      //do the insert code
                  }
                }
