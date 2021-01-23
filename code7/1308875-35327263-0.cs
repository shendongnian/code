    <system.serviceModel>
      <extensions>
        <bindingElementExtensions>
          <add name="gzipMessageEncoding" type="[ProjectName].GZipEncoder.GzipMessageEncodingElement, GZipEncoder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
        </bindingElementExtensions>
      </extensions>
      <client>
        <endpoint />
        <metadata>
          <policyImporters>
            <extension type="[ProjectName].GZipEncoder.GZipMessageEncodingBindingElementImporter, GZipEncoder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null" />
          </policyImporters>
        </metadata>
      </client>
      <bindings>
        <customBinding>
          <binding name="BulkRequestTransmitterBinding">
            <gzipMessageEncoding innerMessageEncoding="textMessageEncoding" />
            <httpsTransport />
          </binding>
        </customBinding>
      </bindings>
    </system.serviceModel>
