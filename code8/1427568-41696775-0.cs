     <Capabilities>
        <Capability Name="internetClient" />
        <uap:Capability Name="removableStorage" />
        <!--When the device's classId is FF * *, there is a predefined name for the class. 
              You can use the name instead of the class id. 
              There are also other predefined names that correspond to a classId.-->
        <DeviceCapability Name="usb">
          <!--SuperMutt Device-->
          <Device Id="vidpid:045E 0611">
            <!--<wb:Function Type="classId:ff * *"/>-->
            <Function Type="name:vendorSpecific" />
          </Device>
        </DeviceCapability>
      </Capabilities>
----------
    private async void btnCopyImages_Click(object sender, RoutedEventArgs e)
            {
    
                // Get the logical root folder for all external storage devices.
                StorageFolder externalDevices = Windows.Storage.KnownFolders.RemovableDevices;
                // Get the first child folder, which represents the SD card.
                StorageFolder sdCard = (await externalDevices.GetFoldersAsync()).FirstOrDefault();
                // An SD card is present and the sdCard variable now contains a to reference it.
                if (sdCard != null)
                {
                    StorageFile resultfile = await sdCard.CreateFileAsync("foo.png", CreationCollisionOption.GenerateUniqueName);
                     string base64 = "/9j/4AAQSkZJRgABAQEAYABgAAD/4RjqR.....;
                     var bytes = Convert.FromBase64String(base64);
                    await FileIO.WriteBytesAsync(resultfile, bytes);
             }
            // No SD card is present.
              else
                 {
                 }
    }
