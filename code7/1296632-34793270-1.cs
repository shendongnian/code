     private void RemoveRowsDuplicated(Meeting model)
            {
                 if (model.Attendees != null)
                 {
                    var temporaryAtendees = new List<Attendees>();
                    foreach(var item in model.Attendees)
                    {
                        if (temporaryAtendees.Contains(item))
                        {
                            context.Attendees.Remove(item);
                        }
                        else
                        {
                            temporaryAtendees.Add(item);
                        }
                    }
                    }
                }
     
