    var app = new Microsoft.Office.Interop.Outlook.Application();
    ...
    var ns = app.Session; // or app.GetNamespace("MAPI");
            
    var entryID = "<apppoinment entry id>";
    var appoinment = ns.GetItemFromID(entryID) as AppointmentItem;
