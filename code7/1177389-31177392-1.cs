    using System;
    using System.IO;
    
    class MyClass {
    	public bool CheckNetworkDrive(String name) {
    		bool result = false;
    		DriveInfo[] drives = DriveInfo.GetDrives();
    		foreach (DriveInfo d in drives) {
    			if (d.Name == name) {
    				result = d.IsReady;
    			}
    		}
    		return result;
    	}
    }
