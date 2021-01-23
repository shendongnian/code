    using Microsoft.ConfigurationManagement.ManagementProvider;
    using Microsoft.ConfigurationManagement.ManagementProvider.WqlQueryEngine;
    
     SmsNamedValuesDictionary namedValues = new SmsNamedValuesDictionary();
     using (WqlConnectionManager connection = new WqlConnectionManager(namedValues)) {
    	connection.Connect("<site server>");
    	IResultObject collection = connection.GetInstance("SMS_Collection.collectionId='<CollectionID>'");
    
    	IResultObject collectionRule = connection.CreateEmbeddedObjectInstance("SMS_CollectionRuleDirect");
    	collectionRule["ResourceClassName"].StringValue = "SMS_R_System";
    	collectionRule["ResourceID"].IntegerValue = <ResourceID>;
    
    	Dictionary<string, object> inParams = new Dictionary<string, object>();
    	inParams.Add("collectionRule", collectionRule);
    	collection.ExecuteMethod("AddMembershipRule", inParams);
    }
