    public List<GraphModel> countRequestCreatedByTypeDefaulPage(int year, int month, String employeeID)
        {
            int count = 0;
            int countEmployees = 0;
            Dictionary<string, int> dataChart = new Dictionary<string, int>();
            DataView dv = _employeeOverrideBO.getRelatedEmployeesRequests(year, month, employeeID);
            StringBuilder listEmployees = new StringBuilder();
           
            foreach (DataRowView rowView in dv) 
            {
                if (countEmployees == 500)
                {
                    List<GraphModel> listReturn = _requestDAO.countRequestCreatedByTypeDefaulPage(listEmployees.ToString());
                   
                    foreach(GraphModel model in listReturn){
                        if (dataChart.ContainsKey(model.SERIES1))
                        {
                            dataChart[model.SERIES1] = dataChart[model.SERIES1] + model.VAL;
                        }
                        else
                        {
                            dataChart[model.SERIES1] = model.VAL;
                        }
                    }
                    listEmployees = new StringBuilder();
                    count = 0;
                    countEmployees = 0;
                }
                DataRow row = rowView.Row;
                String employee = row["EMPLOYEE_ID"].ToString();
                if (count > 0)
                    listEmployees.Append(",");
                listEmployees.Append("'").Append(employee).Append("'");
                count++;
                countEmployees++;
            }
            //Last Call
            List<GraphModel> listReturnLast = _requestDAO.countRequestCreatedByTypeDefaulPage(listEmployees.ToString());
            foreach (GraphModel model in listReturnLast) {
            
                if (dataChart.ContainsKey(model.SERIES1))
                {
                    dataChart[model.SERIES1] = dataChart[model.SERIES1] + model.VAL;
                }
                else
                {
                    dataChart[model.SERIES1] = model.VAL;
                }
            }
            List<GraphModel> list = new List<GraphModel>();
            foreach (KeyValuePair<string, int> entry in dataChart)
            {
                GraphModel model = new GraphModel();
                model.SERIES1 = entry.Key;
                model.VAL = entry.Value;
                list.Add(model);
            }
            return list;
        }
