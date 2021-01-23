      // create Master
      var AL = new AlertLog() 
    { AlertModeID = alertLog.AlertModeID, AlertPriorityID = alertLog.AlertPriorityID};
      // create Details
      var RM = new RecipientMap() { .. = ...}; // Do NOT consider FK here!
      var AM = new AlertMap() { .. = ... }; // Do NOT consider FK here!
    
      // add Details to Master
      AL.RecipentMaps.Add(RM); // FK is automatically set here
      AL.AlertMaps.Add(AM); // FK is automatically set here
    
      db.AlertLog.Add(AL); // add Master
      db.SaveChanges();
