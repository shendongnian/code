    public OwnerLedger appendOwnerLedgerItems(OwnerLedger ownerLedger, Owner owner) {
        object[] results = this.Invoke("appendOwnerLedgerItems", new object[] {
                    owner, ownerLedger});
        return ((OwnerLedger)(results[0]));
    }
