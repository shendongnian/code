    <connectionStrings>
        <add name="ApplicationDB" connectionString="..." />
    </connectionStrings>
    <defaultConnectionFactory type="Your.Class.Namespace.CustomConnectionFactory, YourAssemblyName">
        <parameters>
            <parameter value="ApplicationDb" />
        </parameters>
    </defaultConnectionFactory>
