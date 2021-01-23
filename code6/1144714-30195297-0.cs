            Contractors cons = new Contractors();
            EstimatesQuery est = new EstimatesQuery("es");
            ContractorsQuery cont = new ContractorsQuery("co");
            //cons.Query.LoadDataTable();
         
            DataList dl = (DataList)pn90day.FindControl("dlpreapprovalestimates");
            est.Where(est.FDDKey.Equal(FDDkey));
            est.InnerJoin(cont).On(est.Contractorky == cont.Contractorky);
