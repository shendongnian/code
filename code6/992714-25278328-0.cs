     List<CustomerSummary> summaries = new List<CustomerSummary>();
            for (var i = 0; i < 10; i++)
            {
                var summary = new CustomerSummary() { ID = 1, Name = "foo", balance = 50.00 };
                if (!summaries.Select(s=>s.ID).Contains(summary.ID))
                    summaries.Add(summary);
            }
