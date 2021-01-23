    <configuration>
        <system.web>
            <authentication mode="None" /> <!-- This is the line that needed to be moved -->
            <pages validateRequest="false">
                <compilation debug="true" targetFramework="4.5"/>
                <httpRuntime targetFramework="4.5"/>
                <namespaces>
                    <add namespace="System.Web.Optimization"/>
                    <add namespace="Microsoft.AspNet.Identity"/>
                </namespaces>
                <controls>
                    <add assembly="Microsoft.AspNet.Web.Optimization.WebForms" namespace="Microsoft.AspNet.Web.Optimization.WebForms" tagPrefix="webopt"/>
                </controls>
            </pages>
        </system.web>
    </configuration>
