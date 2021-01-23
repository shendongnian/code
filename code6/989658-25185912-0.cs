    public class Agency : IReplaceable, IApproveable
    {
        public int AgencyID { get; set; }
        int IReplaceable.ParentID
        {
            get;
            set;
        }
        bool IApproveable.IsAwaitingApproval
        {
            get;
            set;
        }
        IApproveable IApproveable.Parent
        {
            get;
            set;
        }
        IReplaceable IReplaceable.Parent
        {
            get;
            set;
        }
    }
