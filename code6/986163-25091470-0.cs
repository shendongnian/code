    bool new_CaseAssign = false;
    if (customEntity.Attributes.Contains("new_CaseAssign"))
    	new_CaseAssign = (bool) customEntity.Attributes["new_CaseAssign"];
    
    if (new_CaseAssign) {
    	activityEntity.Attributes.Add("ownerid", incident.Attributes["ownerid"]);
    }
    else { //something else
    }
