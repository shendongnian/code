    var csvFilteredRecord = (
                    from c in Context.JT_Temp
                    group c by new
                    {
                        c.EnvelopeCode,
                        c.Branch_COA,
                        c.AQ_COA,
                        c.AQ_Branch,
                        c.AQ_PostStatus
                    } into i
                    select new 
                    {
                        EnvelopeCode = i.Key.EnvelopeCode,
                        Branch_COA = i.Key.Branch_COA,
                        AQ_COA = i.Key.AQ_COA,
                        AQ_Branch = i.Key.AQ_Branch,
                        //TO-DO SUM(Amount),
                        AQ_PostStatus = i.Key.AQ_PostStatus
                    });
