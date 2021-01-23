    <?xml version="1.0" encoding="utf-8"?>
    <edmx:Edmx Version="4.0" xmlns:edmx="http://docs.oasis-open.org/odata/ns/edmx">
      <edmx:DataServices>
        <Schema Namespace="WebApiTest" xmlns="http://docs.oasis-open.org/odata/ns/ed
    m">
          <EntityType Name="Foo">
            <Key>
              <PropertyRef Name="Id" />
            </Key>
            <Property Name="Id" Type="Edm.Int32" Nullable="false" />
          </EntityType>
          <EntityType Name="Bar">
            <Key>
              <PropertyRef Name="Id" />
            </Key>
            <Property Name="Id" Type="Edm.Int32" Nullable="false" />
            <NavigationProperty Name="FooThing" Type="WebApiTest.Foo" Nullable="fals
    e" />
          </EntityType>
        </Schema>
        <Schema Namespace="Test" xmlns="http://docs.oasis-open.org/odata/ns/edm">
          <EntityContainer Name="Container">
            <EntitySet Name="Fools" EntityType="WebApiTest.Foo" />
            <EntitySet Name="Footballs" EntityType="WebApiTest.Foo" />
            <EntitySet Name="Bars" EntityType="WebApiTest.Bar">
              <NavigationPropertyBinding Path="FooThing" Target="Fools" />
            </EntitySet>
          </EntityContainer>
        </Schema>
      </edmx:DataServices>
    </edmx:Edmx>
