    <hibernate-configuration-x-factories xmlns="urn:nhibernate-configuration-2.2-x-factories">
      <session-factory name="Configuration">
        <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
        <property name="connection.driver_class">NHibernate.Driver.SQLite20Driver</property>
        <property name="connection.connection_string">Data Source=Configuration.db;Version=3</property>
        <property name="dialect">NHibernate.Dialect.SQLiteDialect</property>
        <property name="query.substitutions">true=1;false=0</property>
        <property name="show_sql">false</property>
        <mapping assembly="DataModel"/>
      </session-factory>
      <session-factory name="Texts">
        <property name="connection.provider">NHibernate.Connection.DriverConnectionProvider</property>
        <property name="connection.driver_class">NHibernate.Driver.SQLite20Driver</property>
        <property name="connection.connection_string">Data Source=Texts.db;Version=3</property>
        <property name="dialect">NHibernate.Dialect.SQLiteDialect</property>
        <property name="query.substitutions">true=1;false=0</property>
        <property name="show_sql">false</property>
        <mapping assembly="DataModel_Texts"/>
      </session-factory>
    </hibernate-configuration-x-factories>
