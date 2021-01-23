    <?xml version="1.0" encoding="utf-8"?>
    <edmx:Edmx Version="4.0" xmlns:edmx="http://docs.oasis-open.org/odata/ns/edmx">
      <edmx:DataServices>
        <Schema Namespace="WebApplication1.Models.OData" xmlns="http://docs.oasis-open.org/odata/ns/edm">
          <EntityType Name="User">
            <Key>
              <PropertyRef Name="Id" />
            </Key>
            <Property Name="Id" Type="Edm.String" Nullable="false" />
            <Property Name="Name" Type="Edm.String" Nullable="false" />
            <NavigationProperty Name="UserRoles" Type="Collection(WebApplication1.Models.OData.UserRole)" />
          </EntityType>
          <EntityType Name="UserRole">
            <Key>
              <PropertyRef Name="UserId" />
              <PropertyRef Name="RoleName" />
            </Key>
            <Property Name="UserId" Type="Edm.String" Nullable="false" />
            <Property Name="RoleName" Type="Edm.String" Nullable="false" />
            <NavigationProperty Name="User" Type="WebApplication1.Models.OData.User" />
          </EntityType>
        </Schema>
        <Schema Namespace="Default" xmlns="http://docs.oasis-open.org/odata/ns/edm">
          <EntityContainer Name="Container">
            <EntitySet Name="Users" EntityType="WebApplication1.Models.OData.User">
              <NavigationPropertyBinding Path="UserRoles" Target="UserRoles" />
            </EntitySet>
            <EntitySet Name="UserRoles" EntityType="WebApplication1.Models.OData.UserRole">
              <NavigationPropertyBinding Path="User" Target="Users" />
            </EntitySet>
          </EntityContainer>
        </Schema>
      </edmx:DataServices>
    </edmx:Edmx>
