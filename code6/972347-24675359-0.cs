    foreach (Event item in myGoogleCalendar.Items)
    {
        if (DB.Events.Where(o => o.GoogleID == item.Id).Count() == 0)
        {
            // create new DB event from Google event, because since it is 
            // not in the DB.Events list, it has not been deleted there earlier, 
            // else there would be an event with IsDeleted=true
        }
        else
        {
            //This event exists in both
            myEvent dbEvent = DB.Events.Where(o => o.GoogleID == item.Id).First();
            if (dbEvent.IsDeleted)
            {
               // delete Google event, since the flag in DB.Events list shows that 
               // it existed earlier and has been deleted in DB.Events list.
            }
            else
            {
                if(item.Updated.Value == dbEvent.UpdateTime) continue;//Same
    
                if (item.Updated.Value > dbEvent.UpdateTime)
                {
                    // update DB event
                }
                else
                {
                    // update Google event
                }
            }
        }
    }
