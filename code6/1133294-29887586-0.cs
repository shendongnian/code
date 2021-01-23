    <Updates>
      <UpdateIdentity UpdateID="E6CF1350-C01B-414D-A61F-263D14D133B4" RevisionNumber="1" />
      <Properties UpdateType="Category" />
      <ApplicabilityRules>
        <IsInstalled>
          <True />
        </IsInstalled>
      </ApplicabilityRules>
      <UpdateIdentity UpdateID="2bf7ed9c-6f43-493a-b156-db20f08c44c4" RevisionNumber="101" />
      <Properties UpdateType="Detectoid" />
      <Relationships />
      <ApplicabilityRules>
        <IsInstalled>
          <b.RegSz Key="HKEY_LOCAL_MACHINE" Subkey="SYSTEM\CurrentControlSet\Control\Nls\Language" Value="InstallLanguage" Comparison="EqualTo" Data="0409" />
        </IsInstalled>
      </ApplicabilityRules>
      <UpdateIdentity UpdateID="6AECE9A4-19E3-4BC7-A20C-070A5E31AFF4" RevisionNumber="100" />
      <Properties UpdateType="Detectoid" />
      <Relationships></Relationships>
      <UpdateIdentity UpdateID="3B4B8621-726E-43A6-B43B-37D07EC7019F" />
      <ApplicabilityRules>
        <IsInstalled>
          <b.WmiQuery Namespace="root\cimv2" WqlQuery="SELECT Manufacturer FROM Win32_ComputerSystem WHERE Manufacturer = 'Dell Inc.' or Manufacturer = 'Samsung Electronics' or Manufacturer = 'Hewlett-Packard' or Manufacturer = 'Gateway'" />
        </IsInstalled>
      </ApplicabilityRules>
    </Updates>
