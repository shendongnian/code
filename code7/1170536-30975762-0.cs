                writer.WriteStartDocument();
                writer.WriteStartElement("GetSafeActivitiesResult");
                foreach (ActivityLogRecord activity in safeActivities)
                {
                    if (activity.Info1.ToLower().Contains(FileName.ToLower()))
                    {
                        // Write out the activity information
                    }
                }
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
