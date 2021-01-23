    public Evidence Evidence
    {
        [SecuritySafeCritical, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries"), SecurityPermission(SecurityAction.Demand, ControlEvidence=true)]
        get
        {
            return this.EvidenceNoDemand;
        }
    }
    internal Evidence EvidenceNoDemand
    {
        [SecurityCritical]
        get
        {
            if (this._SecurityIdentity != null)
            {
                return this._SecurityIdentity.Clone();
            }
            if (!this.IsDefaultAppDomain() && this.nIsDefaultAppDomainForEvidence())
            {
                return GetDefaultDomain().Evidence;
            }
            return new Evidence(new AppDomainEvidenceFactory(this));
        }
    }
     
