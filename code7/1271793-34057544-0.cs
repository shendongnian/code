                ADODB.Stream stream = new ADODB.Stream();
                stream.Type = ADODB.StreamTypeEnum.adTypeBinary;
                stream.Open(System.Reflection.Missing.Value, ADODB.ConnectModeEnum.adModeUnknown, ADODB.StreamOpenOptionsEnum.adOpenStreamUnspecified, null, null); 
                stream.Write(meetingRequest.MimeContent.Content); 
                stream.Position = 0;
                Message.DataSource.OpenObject(stream, "_Stream");
                foreach (CDO.IBodyPart bp in Message.BodyPart.BodyParts)
                {
                    if (bp.ContentMediaType == "text/calendar") 
                    {
                        bp.SaveToFile("c:\\temp\\calendarpart.txt");
                    }
                }
