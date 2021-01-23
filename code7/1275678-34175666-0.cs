    foreach (var section in sections)
            {
                if(section.section_id == section_Id)
                {
    
                    section.syncTime = DateTime.Now;    // Update the Section Sync Time
                    App.DBConnection.Update(section); //update the db
    
                    if (await db.UpdateAsync(section) >= 1)
                        return true;
                }
            }
