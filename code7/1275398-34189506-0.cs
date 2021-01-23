    // IRestService.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;
    
    namespace RestService
    {
        // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
        [ServiceContract]
        public interface IRestServiceImpl
        {
            [OperationContract]
            [WebInvoke(Method = "GET",
                ResponseFormat = WebMessageFormat.Xml,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "xml/{id}")]
            string XMLData(string id);
    
            [OperationContract]
            [WebInvoke(Method = "GET",
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Wrapped,
                UriTemplate = "json/{id}")]
            string JSONData(string id);
        }
    }
    // RestService.cs
    namespace RestService
    {
        public class RestServiceImpl : IRestServiceImpl
        {
            public string JSONData(string id)
            {
                return id;
            }
    
            public string XMLData(string id)
            {
                return id;
            }
        }
    }
    <!-- RestService.svc (Source) -->
    <%@ ServiceHost Language="C#" Debug="true" Service="RestService.RestServiceImpl" CodeBehind="RestService.svc.cs"
        Factory="System.ServiceModel.Activation.WebServiceHostFactory" %>
    <!--  Web.config -->
    <?xml version="1.0"?>
    <configuration>
      <system.web>
        <compilation debug="true" targetFramework="4.0" />
      </system.web>
      <system.serviceModel>
        <services>
          <service name="RestService.RestServiceImpl" behaviorConfiguration="ServiceBehaviour">
            <endpoint address="" binding="webHttpBinding"  bindingConfiguration="webBinding" contract="RestService.IRestServiceImpl" behaviorConfiguration="web">
            </endpoint>
          </service>
        </services>
        <bindings>
          <webHttpBinding>
            <binding name="webBinding">
              <security mode="TransportCredentialOnly">
                <transport clientCredentialType="Windows" proxyCredentialType="Windows">
                </transport>
              </security>
            </binding>
          </webHttpBinding>
        </bindings>
        <behaviors>
          <serviceBehaviors>
            <behavior name="ServiceBehaviour">
              <serviceMetadata httpGetEnabled="true"/>
              <serviceDebug includeExceptionDetailInFaults="false"/>
              <serviceCredentials>
                <windowsAuthentication allowAnonymousLogons="false" includeWindowsGroups="true" />
              </serviceCredentials>
            </behavior>
          </serviceBehaviors>
          <endpointBehaviors>
            <behavior name="web">
              <webHttp/>
            </behavior>
          </endpointBehaviors>
        </behaviors>
      </system.serviceModel>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests="true"/>
      </system.webServer>
    </configuration>
