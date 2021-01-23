    from 
        
        <add name="EntityframeworkTestEntities" connectionString="metadata=res://*/EntityFrameworkTestModel.csdl|res://*/EntityFrameworkTestModel.ssdl|res://*/EntityFrameworkTestModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=EntityframeworkTest;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
    to
        <add name="EntityframeworkTestEntities" connectionString="metadata=EntityFrameworkTestModel.csdl|EntityFrameworkTestModel.ssdl|EntityFrameworkTestModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=.;initial catalog=EntityframeworkTest;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
