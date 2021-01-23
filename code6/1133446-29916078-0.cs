                Region = row.Field<string>("Region"),
                District = row.Field<string>("DistrictName")
            } into g
            select new
            {
                Region = g.Key.Region,
                District = g.Key.District,
                CaseCount = g.Count(),
                ResolvedCaseCount = g.Count(r => "Resolved".Equals(r.Field<string>("CaseStatus")))
            };
            // this will calculate the percentage and add the rows.
            foreach (var entry in districtGroups)
            {
                // determine percentage.
                string percentageResolved;
                if (entry.CaseCount > 0)
                {
                    
                    var percent = (100.0 * entry.ResolvedCaseCount) / entry.CaseCount;
                    percentageResolved = percent.ToString() + "%";
                }
                else // What to do if there are no cases? 
                {
                    percentageResolved = "N/A";
                }
                // add row for the district.
                ReportTable.Rows.Add(
                    entry.Region, entry.District,
                    entry.CaseCount, entry.ResolvedCaseCount,
                    percentageResolved);
            }
