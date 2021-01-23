    static void Main(string[] args)
    {
        using (RegistryKey fipsAlgorithmPolicy = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Control\Lsa\FIPSAlgorithmPolicy", true))
        {
            fipsAlgorithmPolicy.SetValue("Enabled", 1, RegistryValueKind.DWord);
        }
        SHA1 sha = new SHA1Managed(); // throws, which is what you want
    }
