	public static class VirtualSystemSnapshot
	{
		public static object Revert(VirtualMachine vm)
		{
		    ManagementScope scope = new ManagementScope("\\\\" + ServerName + "\\Root\\Virtualization\\V2", Options);
			using (ManagementObject virtualMachine = WmiUtilities.GetVirtualMachine(vmElementName, scope)) {
				using (ManagementObject virtualSystemSettingData = WmiUtilities.GetVirtualSystemSettingData(scope, virtualMachine)) {
					using (ManagementObject virtualSystemSnapshotService = WmiUtilities.GetVirtualSystemSnapshotService(scope)) {
						using (ManagementObject lastSnapshot = WmiUtilities.GetFirstObjectFromCollection(virtualSystemSettingData.GetRelated("Msvm_VirtualSystemSettingData", "Msvm_ParentChildSettingData", null, null, null, null, false, null))) {
							using (ManagementBaseObject inParams = virtualSystemSnapshotService.GetMethodParameters("ApplySnapshot")) {
								inParams("Snapshot") = lastSnapshot;
			                    // In order to apply a snapshot, the virtual machine must first be saved
			                    RequestStateChange.Main(vm, RequestStateChange.RequestedState.Save, false);
								using (ManagementBaseObject outParams = virtualSystemSnapshotService.InvokeMethod("ApplySnapshot", inParams, null)) {
									WmiUtilities.ValidateOutput(outParams, scope);
									// Now that the snapshot has been applied, start the VM back up
									RequestStateChange.Main(vm, RequestStateChange.RequestedState.Start, false);
								}
							}
						}
					}
				}
			}
		}
	}
