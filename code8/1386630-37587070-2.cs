           public string GetAssetRegisterDataTableBySp(ParameterDto parameters)
        {
            string jsonString="";
            string query = string.Format("SELECT * FROM ReportDisplaySetting where Display= 'true'");
            var DisplayColumnSetting = repositoryReportDisplaySetting.ExecuteRawQuery<ReportDisplaySetting>(query).ToList();
            List<string> selectedColumn = DisplayColumnSetting.Select(C => C.ColumnName).ToList();
            string columnOfString = (string.Join(",", selectedColumn.Select(x => x.ToString()).ToArray()));
            List<string> locationIds = new List<string>();
            if (parameters.locationId == 0)
            {
                locationIds = repository.All<CompanyLocationMaster>().AsEnumerable().Where(x => x.CompanyID == parameters.companyId && x.IsActive == true).Select(x => x.LocationID.ToString()).ToList();
            }
            string locationString = "";
            if (locationIds.Count() > 0)
            {
                locationString = string.Join(",", locationIds.ToArray());
            }
            else
            {
                locationString = parameters.locationId.ToString();
            }
            var report = new AssetrakRepository<AssetRegisterReport>();
            DataTable taggingReport = report.GetAssetRegisterReportBySP(parameters.companyId, locationString, columnOfString);
            string strColumns = columnOfString;
            var JSONString = new StringBuilder();
            if (taggingReport.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < taggingReport.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < taggingReport.Columns.Count; j++)
                    {
                        if (j < taggingReport.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + taggingReport.Columns[j].ColumnName.ToString() + "\":" + "\"" + taggingReport.Rows[i][j].ToString().Replace(","," ") + "\",");
                        }
                        else if (j == taggingReport.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + taggingReport.Columns[j].ColumnName.ToString() + "\":" + "\"" + taggingReport.Rows[i][j].ToString().Replace(",", " ") + "\"");
                        }
                    }
                    if (i == taggingReport.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
                
            }
            jsonString=JSONString.ToString();
           
            return jsonString;
        }
  
