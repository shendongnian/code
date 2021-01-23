       /// <devdoc>
        ///    <para>
        ///       Frees any resources associated with this component.
        ///    </para>
        /// </devdoc>
        public void Close() {
            if (Associated) {
                if (haveProcessHandle) {
                    StopWatchingForExit();
                    Debug.WriteLineIf(processTracing.TraceVerbose, "Process - CloseHandle(process) in Close()");
                    m_processHandle.Close();
                    m_processHandle = null;
                    haveProcessHandle = false;
                }
                haveProcessId = false;
                isRemoteMachine = false;
                machineName = ".";
                raisedOnExited = false;
 
                //Don't call close on the Readers and writers
                //since they might be referenced by somebody else while the 
                //process is still alive but this method called.
                standardOutput = null;
                standardInput = null;
                standardError = null;
 
                output = null;
                error = null;
	
 
                Refresh();
            }
        }
