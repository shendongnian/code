    var grouped = dt.AsEnumerable()
                    .GroupBy(row=> row.Field<string>("UserName"))
                    .Select(gr=> new 
                    {
                        UserName = gr.Key,
                        Billable = gr.Where(row=>row.Field<string>("IsBillable")=="Yes")).Sum(row=>row.Field<int>("Hours"),
                        NonBillable = gr.Where(row=>row.Field<string>("IsBillable")=="No")).Sum(row=>row.Field<int>("Hours"),
                    });
