    namespace ZetaProducer.SuperSlimScriptingEngineProfiler.Helper
    {
        using Microsoft.Win32;
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Reflection;
        using System.Security.AccessControl;
        using System.Security.Principal;
        using Zeta.VoyagerLibrary.Common.IO;
        public static class ProfilerComRegistration
        {
            public static readonly Guid Clsid = new Guid(@"1c406fba-59ef-4fb2-938c-c1da182d5914");
            public static void Register()
            {
                var key = checkCreateKey(
                        @"Software\Classes\ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback");
                if (key != null)
                {
                    key.SetValue(null, @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback", RegistryValueKind.String);
                    key.Close();
                }
                key = checkCreateKey(
                        @"Software\Classes\ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback\CLSID");
                if (key != null)
                {
                    key.SetValue(null, @"{1C406FBA-59EF-4FB2-938C-C1DA182D5914}", RegistryValueKind.String);
                    key.Close();
                }
                key = checkCreateKey(
                        @"Software\Classes\CLSID\{1C406FBA-59EF-4FB2-938C-C1DA182D5914}");
                if (key != null)
                {
                    key.SetValue(null, @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback", RegistryValueKind.String);
                    key.Close();
                }
                key = checkCreateKey(
                        @"Software\Classes\CLSID\{1C406FBA-59EF-4FB2-938C-C1DA182D5914}\InprocServer32");
                if (key != null)
                {
                    key.SetValue(null, @"mscoree.dll", RegistryValueKind.String);
                    key.SetValue(@"ThreadingModel", @"Both", RegistryValueKind.String);
                    key.SetValue(@"Class", @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback", RegistryValueKind.String);
                    key.SetValue(@"Assembly", @"ZetaProducer.SuperSlimScriptingEngineProfiler, Version=14.1.0.0, Culture=neutral, PublicKeyToken=null", RegistryValueKind.String);
                    key.SetValue(@"RuntimeVersion", @"v4.0.30319", RegistryValueKind.String);
                    key.SetValue(@"CodeBase", getFileUrl(), RegistryValueKind.String);
                    key.Close();
                }
                key = checkCreateKey(
                        @"Software\Classes\CLSID\{1C406FBA-59EF-4FB2-938C-C1DA182D5914}\InprocServer32\14.1.0.0");
                if (key != null)
                {
                    key.SetValue(@"Class", @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback", RegistryValueKind.String);
                    key.SetValue(@"Assembly", @"ZetaProducer.SuperSlimScriptingEngineProfiler, Version=14.1.0.0, Culture=neutral, PublicKeyToken=null", RegistryValueKind.String);
                    key.SetValue(@"RuntimeVersion", @"v4.0.30319", RegistryValueKind.String);
                    key.SetValue(@"CodeBase", getFileUrl(), RegistryValueKind.String);
                    key.Close();
                }
                key = checkCreateKey(
                        @"Software\Classes\CLSID\{1C406FBA-59EF-4FB2-938C-C1DA182D5914}\ProgId");
                if (key != null)
                {
                    key.SetValue(null, @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback", RegistryValueKind.String);
                    key.Close();
                }
            }
            private static string getFileUrl()
            {
                // ReSharper disable once AssignNullToNotNullAttribute
                var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location),
                    @"ZetaProducer.SuperSlimScriptingEngineProfiler.dll");
                return PathHelper.ConvertFilePathToFileUrl(filePath);
            }
            public static void Unregister()
            {
                var key = Registry.CurrentUser.OpenSubKey(@"Software\Classes", true);
                if (key != null &&
                    new List<string>(key.GetSubKeyNames()).Contains(
                        @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback"))
                {
                    try
                    {
                        key.DeleteSubKeyTree(
                            @"ZetaProducer.SuperSlimScriptingEngineProfiler.SlimScriptEngineProfilerCallback", false);
                    }
                    catch (AccessViolationException)
                    {
                    }
                    key.Close();
                }
                key = Registry.CurrentUser.OpenSubKey(@"Software\Classes\CLSID", true);
                if (key != null &&
                    new List<string>(key.GetSubKeyNames()).Contains(@"{1C406FBA-59EF-4FB2-938C-C1DA182D5914}"))
                {
                    try
                    {
                        key.DeleteSubKeyTree(@"{1C406FBA-59EF-4FB2-938C-C1DA182D5914}", false);
                    }
                    catch (AccessViolationException)
                    {
                    }
                    key.Close();
                }
            }
            private static RegistryKey checkCreateKey(string keyPath)
            {
                var rs = new RegistrySecurity();
                // Jeder.
                var user = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
                rs.AddAccessRule(
                    new RegistryAccessRule(
                        user,
                        RegistryRights.FullControl,
                        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                        PropagationFlags.None,
                        AccessControlType.Allow));
                var key = Registry.CurrentUser.CreateSubKey(keyPath, RegistryKeyPermissionCheck.ReadWriteSubTree, rs);
                return key;
            }
        }
    }
