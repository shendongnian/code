       public static string[] CheckRegKeys(Product product)
        {
            var productEnvironment = MapProductToString.MapProductEnvironment(product);
            var productKeys = new string[50];
            for (var i = 0; i < productKeys.Length; i++)
            {
                if (i < 9)
                {
                    productKeys[i] = string.Format("{0}#0{1}", productEnvironment, i + 1);
                    continue;
                }
                productKeys[i] = string.Format("{0}#{1}", productEnvironment, i + 1);
            }
            return productKeys;
        }
        public static string FindNextEnvironmentForInstallation(Product product)
        {
            var productName = MapProductToString.MapProductToRegistryName(product);
            var productKeys = CheckRegKeys(product);
            using (var componentsKey = Registry.LocalMachine.OpenSubKey(string.Format(@"Software\Wow6432Node\{0}", productName), false))
            {
                if (componentsKey == null)
                {
                    Registry.LocalMachine.CreateSubKey(string.Format(@"Software\Wow6432Node\{0}", productName));
                    return string.Format("I0{0}", 1);
                }
                var environments = componentsKey.GetSubKeyNames();
                if (environments.Length <= 0)
                {
                    var result = string.Format("I0{0}", 1);
                    return result;
                }
                for (var i = 0; i < productKeys.Length; i++)
                {
                    if (environments.Length < i + 1)
                    {
                        if (i < 9)
                        {
                            var result = string.Format("I0{0}", i + 1);
                            return result;
                        }
                        var result2 = string.Format("I{0}", i + 1);
                        return result2;
                    }
                }
            }
            return null;
        }
