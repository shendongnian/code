    // sending to all with only alert message
    var parsePush = new ParsePush();
    parsePush.Alert="hi";
    await parsePush.SendAsync();
    
    // sending to all with your own data
    parsePush.Data= new Dictionary<string, object>
                {
                    {"alert", message},// this is replacement for parsePush.Alert
                    {"sound", "notify.caf"},// for ios
                    {"badge", "Increment"}// for ios notification count increment on icon
                };
    await parsePush.SendAsync();
    // Sending with custom data, you can add your own properties in the 
    // dictionary and send, which will be received by the mobile devices
    {"reference_type", referenceType}// add to dictionary
    {"reference_id", referenceType}
----
    // adding query/conditions 
    int[] smartusers={1,2,3,4,5};
    parsePush.Query = new ParseQuery<ParseInstallation>()
              .Where(i => smartusers.Contains(i.Get<int>("ContactID")));
    // ContactID is a propery in ParseInstallation, that i added
