            using (LINQSQLDataContext c = new LINQSQLDataContext ())
            {
                var items = c.VehEcus.Select(t => new
                {
                    a = t.szModel,
                    b = t.modelID
                }).Distinct()
                .AsEnumerable().Select(t => new
                {
                    displayMember = String.Format("{0}-{1}", t.a, t.b)
                });
                cmbModel.DisplayMember = "displayMember";
                cmbModel.DataSource = items.ToList();
            }
