    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Win32;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    public static class PerfMapper {
        private static Dictionary<string, int> English;
        private static Dictionary<int, string> Localized;
    
        public static PerformanceCounter FromEnglish(string category, string name, string instance = null) {
            return new PerformanceCounter(Map(category), Map(name), instance);
        }
    
        public static PerformanceCounter FromIndices(int category, int name, string instance = null) {
            return new PerformanceCounter(PdhMap(category), PdhMap(name), instance);
        }
    
        public static bool HasName(string name) {
            if (English == null) LoadNames();
            if (!English.ContainsKey(name)) return false;
            var index = English[name];
            return !Localized.ContainsKey(index);
        }
    
        public static string Map(string text) {
            if (HasName(text)) return Localized[English[text]];
            else return text;
        }
    
        private static string PdhMap(int index) {
            int size = 0;
            uint ret = PdhLookupPerfNameByIndex(null, index, null, ref size);
            if (ret == 0x800007D2) {
                var buffer = new StringBuilder(size);
                ret = PdhLookupPerfNameByIndex(null, index, buffer, ref size);
                if (ret == 0) return buffer.ToString();
            }
            throw new System.ComponentModel.Win32Exception((int)ret, "PDH lookup failed");
        }
    
        private static void LoadNames() {
            string[] english;
            string[] local;
            // Retrieve English and localized strings
            using (var hklm = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)) {
                using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\009")) {
                    english = (string[])key.GetValue("Counter");
                }
                using (var key = hklm.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Perflib\CurrentLanguage")) {
                    local = (string[])key.GetValue("Counter");
                }
            }
            // Create English lookup table
            English = new Dictionary<string, int>(english.Length / 2, StringComparer.InvariantCultureIgnoreCase);
            for (int ix = 0; ix < english.Length - 1; ix += 2) {
                int index = int.Parse(english[ix]);
                if (!English.ContainsKey(english[ix + 1])) English.Add(english[ix + 1], index);
            }
            // Create localized lookup table
            Localized = new Dictionary<int, string>(local.Length / 2);
            for (int ix = 0; ix < local.Length - 1; ix += 2) {
                int index = int.Parse(local[ix]);
                Localized.Add(index, local[ix + 1]);
            }
        }
        [DllImport("pdh.dll", CharSet = CharSet.Auto)]
        private static extern uint PdhLookupPerfNameByIndex(string machine, int index, StringBuilder buffer, ref int bufsize);
    }
