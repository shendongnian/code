    ~~~
      <ItemGroup>
        <Folder Include="Data\" />
        <Folder Include="Data\Data2\" />
        <Folder Include="Data2\" />
      </ItemGroup>
      <ItemGroup>
        <None Include="AGenericFile.txt">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
        <None Include="Data\file1.txt">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
        <None Include="Data\Data2\file2.txt">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
        <None Include="Data2\file3.txt">
          <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
        </None>
      </ItemGroup>
    ~~~
