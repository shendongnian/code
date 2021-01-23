        public class WorkHistoryGridSetMapper : IResultSetMapper<WorkHistoryGrid>
    {
        public IEnumerable<WorkHistoryGrid> MapSet(IDataReader reader)
        {
            List<WorkHistoryGrid> workHistoryLst = new List<WorkHistoryGrid>();
            using (reader) // Dispose the reader when we're done
            {
                while (reader.Read())
                {
                    WorkHistoryGrid workHist = new WorkHistoryGrid();
                    workHist.Amount = reader.GetValue(reader.GetOrdinal("Amount")).ToString();
                    workHist.DateBalanced = reader.GetValue(reader.GetOrdinal("DateBalanced")).ToString();
                    workHist.Employer = reader.GetValue(reader.GetOrdinal("Employer")).ToString();
                    workHist.EmployerName = reader.GetValue(reader.GetOrdinal("EmployerName")).ToString();
                    workHist.Fund = reader.GetValue(reader.GetOrdinal("Fund")).ToString();
                    workHist.FundType = reader.GetValue(reader.GetOrdinal("FundType")).ToString();
                    workHist.Hours = reader.GetValue(reader.GetOrdinal("Hours")).ToString();
                    workHist.Local = reader.GetValue(reader.GetOrdinal("Local")).ToString();
                    workHist.Period = reader.GetValue(reader.GetOrdinal("Period")).ToString();
                    workHist.Plan = reader.GetValue(reader.GetOrdinal("Plan")).ToString();
                    workHist.RateAmount = reader.GetValue(reader.GetOrdinal("RateAmount")).ToString();
                    workHist.RateType = reader.GetValue(reader.GetOrdinal("RateType")).ToString();
                    workHist.Status = reader.GetValue(reader.GetOrdinal("Status")).ToString();
                    workHist.WorkMonth = reader.GetValue(reader.GetOrdinal("WorkMonth")).ToString();
                    workHist.MergeData = new WorkHistoryGridMergeData
                    {
                        MergeDateMerged = reader.GetValue(reader.GetOrdinal("MergeDateMerged")).ToString(),
                        MergeLastUpdated = reader.GetValue(reader.GetOrdinal("MergeLastUpdated")).ToString(),
                        MergeLastUpdatedUserId = reader.GetValue(reader.GetOrdinal("MergeLastUpdatedUserId")).ToString(),
                        MergeLastUpdatedUserType = reader.GetValue(reader.GetOrdinal("MergeLastUpdatedUserType")).ToString(),
                        MergeNewSsn = reader.GetValue(reader.GetOrdinal("MergeNewSsn")).ToString(),
                        MergeNotes = reader.GetValue(reader.GetOrdinal("MergeNotes")).ToString(),
                        MergeOldSsn = reader.GetValue(reader.GetOrdinal("MergeOldSsn")).ToString(),
                        MergeTrustId = reader.GetValue(reader.GetOrdinal("MergeTrustId")).ToString(),
                        MergeUserName = reader.GetValue(reader.GetOrdinal("MergeUserName")).ToString()
                    };
                    workHistoryLst.Add(workHist);
                };
            }
            return workHistoryLst;
        }
    }
