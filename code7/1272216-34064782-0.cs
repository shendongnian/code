    //Setup a string that will call a button click event
    var BtnSendAndSaveClick =  "document.getElementById('"
                                      + ApprovalButton.ClientID.ToString() + "')"
                                      + ".click();";
         
    //Call the other button
    SaveEntry.Attributes.Add("OnClick", BtnSendAndSaveClick );
