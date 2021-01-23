     ReportDocument report = new ReportDocument();
                report.Load("C:\\Users\\Desktop\\CrystalReport1.rpt");
    
                TableLogOnInfo Table = new TableLogOnInfo();
                ConnectionInfo Connection = new ConnectionInfo();
                Tables Tables;
    
                ParameterFieldDefinitions Parameters;
                ParameterFieldDefinition Parameter;
                ParameterValues Values = new ParameterValues();
                ParameterDiscreteValue DiscreteValue = new ParameterDiscreteValue();
    
                DiscreteValue.Value = dateTimePicker1.Text;
                Parameters = report.DataDefinition.ParameterFields;
                Parameter = Parameters["fromdate"];
                Values = Parameter.CurrentValues;
    
                Values.Clear();
                Values.Add(DiscreteValue);
                Parameter.ApplyCurrentValues(Values);
    
                DiscreteValue.Value = dateTimePicker2.Text;
                Parameters = report.DataDefinition.ParameterFields;
                Parameter = Parameters["todate"];
                Values = Parameter.CurrentValues;
    
                Values.Add(DiscreteValue);
                Parameter.ApplyCurrentValues(Values);
    
                Connection.ServerName = "Your servername in Set Datasource Location";
                Connection.DatabaseName = "Your databasename in Set Datasource Location";
                Connection.UserID = "your username";
                Connection.Password = "your password";
    
                Tables = report.Database.Tables;
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in Tables)
                {
                    Table = table.LogOnInfo;
                    Table.ConnectionInfo = Connection;
                    table.ApplyLogOnInfo(Table);
                }
    
                crystalReportViewer1.ReportSource = report;
                crystalReportViewer1.Refresh();
