    public void activeDeviceProcessFormClosed(int deviceNumber)
    {
         this.Invoke((MethodInvoker)delegate
         {
             foreach (ActiveDeviceProcess i in activeDeviceProcessForms)
             {
                 if (i.device.deviceNumber == deviceNumber)
                 {
                     activeDeviceProcessForms.Remove(i);
                     break;//----> this was added.
                 }
             }
         });
    }
