    if ((customEntity.Attributes.Contains("new_caseassign")) && customEntity.Attributes["new_caseassign"] != null)
    {
        if ((bool)customEntity.Attributes["new_caseassign"])
        {
            activityEntity.Attributes.Add("ownerid", incident.Attributes["ownerid"]);
        }
    }
    else 
    { //something else
    }
