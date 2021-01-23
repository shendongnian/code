    <Project...>
      ....
      <Target Name="RemoveSatelliteAssemblies" AfterTargets="ResolveAssemblyReferences">
    	<ItemGroup>
    		<ReferenceCopyLocalPaths Remove="@(ReferenceSatellitePaths)" />
    	</ItemGroup>
      </Target>
    </Project>
