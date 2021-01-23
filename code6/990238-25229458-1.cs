    <hibernate-configuration xmlns="urn:nhibernate-configuration-2.2">
        <session-factory>
            <property name="connection.connection_string">Server=DB2...
            ...
            <mapping assembly="MyProject.Data" />
            <mapping assembly="MyProject.DataForDB2" />
        </session-factory>
