     var endCpuCycles = ThreadCpuTimeUtility.GetTheadCycles();
     Thread.EndThreadAffinity();
     var cpuMicroseconds = ThreadCpuTimeUtility.GetThreadCpuMicroseconds(
         _startCpuCycles, 
         endCpuCycles);
