      <!--
      Avoid collision of older System.Data.Services.Client with newer Microsoft.Data.Services.Client
      when mixed due to PackageReferences
      -->
      <Target Name="ChangeAliasesOfNugetRefs" BeforeTargets="FindReferenceAssembliesForReferences;ResolveReferences">
        <ItemGroup>
          <ReferencePath Condition="'%(FileName)' == 'System.Data.Services.Client'">
            <Aliases>legacy</Aliases>
          </ReferencePath>
        </ItemGroup>
      </Target>
