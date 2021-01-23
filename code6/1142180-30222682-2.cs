    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    namespace Microsoft.ServiceModel.Samples
    {
        // Define a service contract.
        [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    	public interface IIsolatedAuthService
    	{
            [OperationContract]
            string IsAuthorized(string username, string roleName, string token);
            [OperationContract]
            string AuthenticateUser(string username, string encryptedPassword);
    	}
    }
