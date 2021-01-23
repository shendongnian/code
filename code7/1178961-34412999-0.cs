      var reg = Registry.LocalMachine.OpenSubKey("Software");
        SearchRecursive(reg);
        ...
        private void SearchRecursive(ReigstryKey reg)
        {
           var subkeys = reg.GetSubKeyNames();
           var values = reg.GetValueNames();
           foreach (var value in values)
           {
              ...
           }
        }
