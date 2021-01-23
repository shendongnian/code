                    Google.Apis.Drive.v3.Data.File f_file1 = null;
                    f_file1 = m_DriveService.Files.Get("fileID").Execute();
                    EventAttachment attach1 = new EventAttachment();
                    //attach.FileId = file.Id;
                    attach1.Title = f_file1.Name;
                    attach1.MimeType = f_file1.MimeType;
                    attach1.FileUrl = FileURL;
                    List<EventAttachment> listEveAttach1 = new List<EventAttachment>();
                    listEveAttach1.Add(attach1);
                    f_CalEventObj.Attachments = listEveAttach1;
                   
                    m_CalService.Events.Insert(f_CalEventObj, obj_addedCal).SupportsAttachments = true;
                    EventsResource.InsertRequest obj_request = m_CalService.Events.Insert(f_CalEventObj, obj_addedCal);
                    obj_request.SupportsAttachments = true;
                    Google.Apis.Calendar.v3.Data.Event obj_AddedEvent = obj_request.Execute();
