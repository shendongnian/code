    /// <summary>
    /// Defines a Windows privilege.
    /// </summary>
    public sealed class Privilege : IDisposable
    {
        private static Type _privilegeType;
        private object _privilege;
        static Privilege()
        {
            _privilegeType = typeof(string).Assembly.GetType("System.Security.AccessControl.Privilege", false); // mscorlib
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Privilege"/> class and enable the privilege.
        /// </summary>
        /// <param name="name">The privilege name.</param>
        public Privilege(string name)
            : this(name, true)
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Privilege" /> class.
        /// </summary>
        /// <param name="name">The privilege name.</param>
        /// <param name="enable">if set to <c>true</c> the privilege is enabled.</param>
        public Privilege(string name, bool enable)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (_privilegeType == null)
                throw new NotSupportedException();
            _privilege = _privilegeType.GetConstructors()[0].Invoke(new object[] { name });
            if (enable)
            {
                Enable();
            }
        }
        /// <summary>
        /// Disable this privilege from the current thread. 
        /// </summary>
        public void Revert()
        {
            _privilegeType.InvokeMember("Revert", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, _privilege, null);
        }
        /// <summary>
        /// Gets a value indicating whether Revert must be called.
        /// </summary>
        /// <value>
        ///   <c>true</c> if Revert must be called; otherwise, <c>false</c>.
        /// </value>
        public bool NeedToRevert
        {
            get
            {
                return (bool)_privilegeType.InvokeMember("NeedToRevert", BindingFlags.Public | BindingFlags.Instance | BindingFlags.GetProperty, null, _privilege, null);
            }
        }
        /// <summary>
        /// Enables this privilege to the current thread. 
        /// </summary>
        public void Enable()
        {
            _privilegeType.InvokeMember("Enable", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, _privilege, null);
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (NeedToRevert)
            {
                Revert();
            }
        }
        /// <summary>
        /// The SE_ASSIGNPRIMARYTOKEN_NAME privilege.
        /// </summary>
        public const string AssignPrimaryToken = "SeAssignPrimaryTokenPrivilege";
        /// <summary>
        /// The SE_AUDIT_NAME privilege.
        /// </summary>
        public const string Audit = "SeAuditPrivilege";
        /// <summary>
        /// The SE_BACKUP_NAME privilege.
        /// </summary>
        public const string Backup = "SeBackupPrivilege";
        /// <summary>
        /// The SE_CHANGE_NOTIFY_NAME privilege.
        /// </summary>
        public const string ChangeNotify = "SeChangeNotifyPrivilege";
        /// <summary>
        /// The SE_CREATE_GLOBAL_NAME privilege.
        /// </summary>
        public const string CreateGlobal = "SeCreateGlobalPrivilege";
        /// <summary>
        /// The SE_CREATE_PAGEFILE_NAME privilege.
        /// </summary>
        public const string CreatePageFile = "SeCreatePagefilePrivilege";
        /// <summary>
        /// The SE_CREATE_PERMANENT_NAME privilege.
        /// </summary>
        public const string CreatePermanent = "SeCreatePermanentPrivilege";
        /// <summary>
        /// The SE_CREATE_SYMBOLIC_LINK_NAME privilege.
        /// </summary>
        public const string CreateSymbolicLink = "SeCreateSymbolicLinkPrivilege";
        /// <summary>
        /// The SE_CREATE_TOKEN_NAME privilege.
        /// </summary>
        public const string CreateToken = "SeCreateTokenPrivilege";
        /// <summary>
        /// The SE_DEBUG_NAME privilege.
        /// </summary>
        public const string Debug = "SeDebugPrivilege";
        /// <summary>
        /// The SE_ENABLE_DELEGATION_NAME privilege.
        /// </summary>
        public const string EnableDelegation = "SeEnableDelegationPrivilege";
        /// <summary>
        /// The SE_IMPERSONATE_NAME privilege.
        /// </summary>
        public const string Impersonate = "SeImpersonatePrivilege";
        /// <summary>
        /// The SE_INC_BASE_PRIORITY_NAME privilege.
        /// </summary>
        public const string IncreaseBasePriority = "SeIncreaseBasePriorityPrivilege";
        /// <summary>
        /// The SE_INCREASE_QUOTA_NAME privilege.
        /// </summary>
        public const string IncreaseQuota = "SeIncreaseQuotaPrivilege";
        /// <summary>
        /// The SE_INC_WORKING_SET_NAME privilege.
        /// </summary>
        public const string IncreaseWorkingSet = "SeIncreaseWorkingSetPrivilege";
        /// <summary>
        /// The SE_LOAD_DRIVER_NAME privilege.
        /// </summary>
        public const string LoadDriver = "SeLoadDriverPrivilege";
        /// <summary>
        /// The SE_LOCK_MEMORY_NAME privilege.
        /// </summary>
        public const string LockMemory = "SeLockMemoryPrivilege";
        /// <summary>
        /// The SE_MACHINE_ACCOUNT_NAME privilege.
        /// </summary>
        public const string MachineAccount = "SeMachineAccountPrivilege";
        /// <summary>
        /// The SE_MANAGE_VOLUME_NAME privilege.
        /// </summary>
        public const string ManageVolume = "SeManageVolumePrivilege";
        /// <summary>
        /// The SE_PROF_SINGLE_PROCESS_NAME privilege.
        /// </summary>
        public const string ProfileSingleProcess = "SeProfileSingleProcessPrivilege";
        /// <summary>
        /// The SE_RELABEL_NAME privilege.
        /// </summary>
        public const string Relabel = "SeRelabelPrivilege";
        /// <summary>
        /// The SE_REMOTE_SHUTDOWN_NAME privilege.
        /// </summary>
        public const string RemoteShutdown = "SeRemoteShutdownPrivilege";
        ///// <summary>
        ///// The SE_RESERVE_PROCESSOR_NAME privilege.
        ///// </summary>
        //public const string ReserveProcessor = "SeReserveProcessorPrivilege";
        /// <summary>
        /// The SE_RESTORE_NAME privilege.
        /// </summary>
        public const string Restore = "SeRestorePrivilege";
        /// <summary>
        /// The SE_SECURITY_NAME privilege.
        /// </summary>
        public const string Security = "SeSecurityPrivilege";
        /// <summary>
        /// The SE_SHUTDOWN_NAME privilege.
        /// </summary>
        public const string Shutdown = "SeShutdownPrivilege";
        /// <summary>
        /// The SE_SYNC_AGENT_NAME privilege.
        /// </summary>
        public const string SyncAgent = "SeSyncAgentPrivilege";
        /// <summary>
        /// The SE_SYSTEM_ENVIRONMENT_NAME privilege.
        /// </summary>
        public const string SystemEnvironment = "SeSystemEnvironmentPrivilege";
        /// <summary>
        /// The SE_SYSTEM_PROFILE_NAME privilege.
        /// </summary>
        public const string SystemProfile = "SeSystemProfilePrivilege";
        /// <summary>
        /// The SE_SYSTEMTIME_NAME privilege.
        /// </summary>
        public const string SystemTime = "SeSystemtimePrivilege";
        /// <summary>
        /// The SE_TAKE_OWNERSHIP_NAME privilege.
        /// </summary>
        public const string TakeOwnership = "SeTakeOwnershipPrivilege";
        /// <summary>
        /// The SE_TCB_NAME privilege.
        /// </summary>
        public const string TrustedComputingBase = "SeTcbPrivilege";
        /// <summary>
        /// The SE_TIME_ZONE_NAME privilege.
        /// </summary>
        public const string TimeZone = "SeTimeZonePrivilege";
        /// <summary>
        /// The SE_TRUSTED_CREDMAN_ACCESS_NAME privilege.
        /// </summary>
        public const string TrustedCredentialManagerAccess = "SeTrustedCredManAccessPrivilege";
        /// <summary>
        /// The SE_UNDOCK_NAME privilege.
        /// </summary>
        public const string Undock = "SeUndockPrivilege";
        /// <summary>
        /// The SE_UNSOLICITED_INPUT_NAME privilege.
        /// </summary>
        public const string UnsolicitedInput = "SeUnsolicitedInputPrivilege";
    }
