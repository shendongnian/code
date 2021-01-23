    static void Main(string[] args)
    {
        SHA1 sha = new SHA1Managed(); // Does not throw, which is expected
        using (RegistryKey fipsAlgorithmPolicy = Registry.LocalMachine.OpenSubKey(@"System\CurrentControlSet\Control\Lsa\FIPSAlgorithmPolicy", true))
        {
            fipsAlgorithmPolicy.SetValue("Enabled", 1, RegistryValueKind.DWord);
        }
        sha = new SHA1Managed(); // Also does not throw, which is a shame
    }
