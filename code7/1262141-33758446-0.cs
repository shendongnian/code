    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Runtime.InteropServices.ComTypes;
    public class VSSolution {
        public string Name { get; set; }
        public EnvDTE.Solution Solution { get; set; }
    }
    public static class VSAutomation {
        public static List<VSSolution> GetRunningSolutions() {
            var instances = new List<VSSolution>();
            // Get running object table reference iterator
            IRunningObjectTable Rot;
            int hr = GetRunningObjectTable(0, out Rot);
            if (hr < 0) throw new COMException("No rot?", hr);
            IEnumMoniker monikerEnumerator;
            Rot.EnumRunning(out monikerEnumerator);
            // And iterate
            IntPtr pNumFetched = new IntPtr();
            IMoniker[] monikers = new IMoniker[1];
            while (monikerEnumerator.Next(1, monikers, pNumFetched) == 0) {
                IBindCtx bindCtx;
                int hr2 = CreateBindCtx(0, out bindCtx);
                if (hr < 0) continue;
                // Check if display ends with ".sln"
                string displayName;
                monikers[0].GetDisplayName(bindCtx, null, out displayName);
                if (displayName.EndsWith(".sln", StringComparison.CurrentCultureIgnoreCase)) {
                    object obj;
                    Rot.GetObject(monikers[0], out obj);
                    if (obj is EnvDTE.Solution) {
                        instances.Add(new VSSolution { Name = displayName, Solution = (EnvDTE.Solution)obj });
                    }
                    else Marshal.ReleaseComObject(obj);
                }
            }
            return instances;
        }
        [DllImport("ole32.dll")]
        private static extern int CreateBindCtx(uint reserved, out IBindCtx ppbc);
        [DllImport("ole32.dll")]
        private static extern int GetRunningObjectTable(int reserved, out IRunningObjectTable prot);
    }
