    public class OpportunityMaintPXExt : PXGraphExtension<OpportunityMaint>
    {
        public override void Initialize()
        {
            PXGraph.InstanceCreated.AddHandler<SOOrderEntry>((graph) =>
            {
                graph.RowUpdating.AddHandler<SOOrder>((sender, e) =>
                {
                    SOOrder soData = e.NewRow as SOOrder;
                    if (soData != null)
                    {
                        if (sender.GetStatus(soData) == PXEntryStatus.Inserted)
                        {
                            CROpportunity opData = Base.Opportunity.Current;
                            CROpportunityPXExt opDataExt = PXCache<CROpportunity>.GetExtension<CROpportunityPXExt>(opData);
                            soData.TermsID = opDataExt.UsrTermsID;
                            soData.ShipVia = opDataExt.UsrShipVia;
                        }
                    }
                });
            });
        }
    }
