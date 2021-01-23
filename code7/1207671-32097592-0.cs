    <system.serviceModel>
        <behaviors>
          <serviceBehaviors>
            <behavior name="">
             <serviceMetadata httpGetEnabled="true" />
             <serviceDebug includeExceptionDetailInFaults="false" />
            </behavior>
          </serviceBehaviors>
        </behaviors>
        <bindings>
        </bindings>
        <services>
          <service name="Service1">
            <endpoint address="Service1.svc" name="Service1Endpoint"
               binding="basicHttpBinding" contract="ServiceReference1.IService1" />
            <host>
             <baseAddresses>
               <add baseAddress="http://localhost:8095/Service1.svc" />
             </baseAddresses>
            </host>
          </service>
        </services>
    </system.serviceModel>
