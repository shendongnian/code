    public class BranchCircuitStatusScheduleEntry : NWatchCustomScheduleEntryBase, INWatchCustomScheduleEntry
    {
        public BranchCircuitStatusScheduleEntry(INWatchSchedulerApplication application, ICasOperations casOperations)
            : base(application, DevOpsScheduleFrequency.Minute, 15, 0, DevOpsScheduleFlags.Always)
        {
            CasOperations = casoperations;
        }
    
        public CasOperations CasOperations { get; private set; }
    }
