	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
    public class Value
    {
        public string type { get; set; }
        public string objectType { get; set; }
        public string objectId { get; set; }
        public object deletionTimestamp { get; set; }
        public string appDisplayName { get; set; }
        public string name { get; set; }
        public string dataType { get; set; }
        public bool isSyncedFromOnPremises { get; set; }
        public List<string> targetObjects { get; set; }
    }
    public class RootObject // was missing
    {
        public string metadata { get; set; }
        public List<Value> value { get; set; }
    }
	public void Main()
	{
		string json = "{'odata.metadata':'https://graph.windows.net/mysaasapp.onmicrosoft.com/$metadata#directoryObjects/Microsoft.DirectoryServices.ExtensionProperty','value':[{'odata.type':'Microsoft.DirectoryServices.ExtensionProperty','objectType':'ExtensionProperty','objectId':'f751a646-2cc1-4e30-bfc6-a8217c0ce0a3','deletionTimestamp':null,'appDisplayName':'','name':'extension_33e037a7b1aa42ab96936c22d01ca338_Modulos','dataType':'String','isSyncedFromOnPremises':false,'targetObjects':['User']},{'odata.type':'Microsoft.DirectoryServices.ExtensionProperty','objectType':'ExtensionProperty','objectId':'80aabe1b-b020-41d1-bd2d-cc04af264fe5','deletionTimestamp':null,'appDisplayName':'','name':'extension_33e037a7b1aa42ab96936c22d01ca338_ModulesPerUser','dataType':'String','isSyncedFromOnPremises':false,'targetObjects':['User']},{'odata.type':'Microsoft.DirectoryServices.ExtensionProperty','objectType':'ExtensionProperty','objectId':'6e3d7592-7a66-4792-b408-891251197868','deletionTimestamp':null,'appDisplayName':'','name':'extension_33e037a7b1aa42ab96936c22d01ca338_Comasdasa3dsdaspInfo','dataType':'String','isSyncedFromOnPremises':false,'targetObjects':['User']},{'odata.type':'Microsoft.DirectoryServices.ExtensionProperty','objectType':'ExtensionProperty','objectId':'93a26374-4135-4f29-9f24-4154522449ec','deletionTimestamp':null,'appDisplayName':'','name':'extension_33e037a7b1aa42ab96936c22d01ca338_CompInfo','dataType':'String','isSyncedFromOnPremises':false,'targetObjects':['User']},{'odata.type':'Microsoft.DirectoryServices.ExtensionProperty','objectType':'ExtensionProperty','objectId':'21a8a3d4-f4b4-45b4-8d07-55d450db35f2','deletionTimestamp':null,'appDisplayName':'','name':'extension_33e037a7b1aa42ab96936c22d01ca338_CompanyNameForSaasApp','dataType':'String','isSyncedFromOnPremises':false,'targetObjects':['User']},{'odata.type':'Microsoft.DirectoryServices.ExtensionProperty','objectType':'ExtensionProperty','objectId':'7b3109e0-8710-4d1a-81c3-2b6a83fb62ee','deletionTimestamp':null,'appDisplayName':'','name':'extension_33e037a7b1aa42ab96936c22d01ca338_Compania','dataType':'String','isSyncedFromOnPremises':false,'targetObjects':['User']}]}";
		var o = JsonConvert.DeserializeObject<RootObject>(json);
		Console.WriteLine(o.value[0].name);
	}
