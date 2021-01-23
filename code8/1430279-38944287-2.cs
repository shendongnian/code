    var Const_olFolderContacts = 10;
    var objApp = new ActiveXObject(“Outlook.Application”);
    var objNS = objApp.GetNamespace(“MAPI”);
    var colContacts = objNS.GetDefaultFolder(Const_olFolderContacts).Items
    for( var i=1; i<=colContacts.count;i++)
    {
     var v = colContacts.item(i);
     alert(v[“FullName”]+” (“+v[“Email1Address”]+”)”);
    }
