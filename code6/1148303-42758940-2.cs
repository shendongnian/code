        using System.Management;
        private void getAvailablePorts()
        {
            // Get friendly names to go along with the actual portNames
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SERIALPORT"))
            {
               var portDictionary = new Dictionary<string, string>();
               var portNames = SerialPort.GetPortNames().OrderByDescending(s => s.GetAlphaNumericOrderToken()).ToArray<object>();
               var portList = searcher.Get().Cast<ManagementBaseObject>().ToList();
                foreach( var portName in portNames)
                {
                    // WMI does not always find all com ports so provide a null alternative
                    var portDesc = portList.Where(p => p["DeviceID"].ToString() == portName.ToString()).Select(q => q["Caption"].ToString()).FirstOrDefault() ?? portName.ToString();
                    portDictionary.Add(portName.ToString(), portDesc);
                }
                portComboBox.DataSource = new BindingSource(portDictionary, null);
                portComboBox.DisplayMember = "Value";
                portComboBox.ValueMember = "Key";
                // I set my comboBox Selected entry to be the one with a friendly name 
                // beginning with "Teensy" (of course yours will be different, 
                // or you can leave this out)
                portComboBox.SelectedIndex = portComboBox.FindString("Teensy");  // -1 if not found
                if (portComboBox.SelectedIndex < 0)
                    portComboBox.Selected = 0;
            }
        }
