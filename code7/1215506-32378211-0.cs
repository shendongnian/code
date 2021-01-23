    ConversationId convId = item.ConversationId; 
    PropertySet properties = new PropertySet(BasePropertySet.IdOnly,                                                       
                                                    ItemSchema.Subject,
                                                    ItemSchema.InReplyTo,
                                                    ItemSchema.DateTimeReceived,
                                                    ItemSchema.DateTimeSent,
                                                    ItemSchema.DisplayCc,
                                                    ItemSchema.IsFromMe,                                                         
                                                    ItemSchema.DisplayTo,
                                                    ItemSchema.HasAttachments,
                                                    ItemSchema.Attachments,
                                                    ItemSchema.UniqueBody);
    
    // Request conversation items. This results in a call to the service.         
    ConversationResponse response = service.GetConversationItems
    (convId,properties,null,null,
    ConversationSortOrder.TreeOrderDescending);
        
    foreach (ConversationNode node in response.ConversationNodes)
    {
    	foreach (Item item in node.Items)                   
             {
    		Console.WriteLine("   Received: " + item.DateTimeReceived);
    		Console.WriteLine("   Received: " + item.uniquebody);
    		Console.WriteLine("   Received: " + item.subject);
    		 if (item.HasAttachments)
                     {
    			  foreach(Attachment attach in item.Attachments)
                               {
    				FileAttachment fileAttachment = attach as FileAttachment;
    				fileAttachment.Load(sFilePath);
    			    }
    		  }
    	  }
    }
