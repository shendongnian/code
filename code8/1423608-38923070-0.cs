    private void AutoLoadCalendar()
        {
            string constringF = @"Data Source=|DataDirectory|\cadastramentodb.sdf;Persist Security Info=False";
            string QueryF = 
                "DECLARE @DiaSemana AS INT " +
                "SET @DiaSemana=DATEPART(DW,@Fecha) " +
                " " +
                "SELECT * " +
                "FROM Funcionarios " +
                "WHERE [status] = N'Ativo' AND datafimcontrato >= DATEADD(DD,@DiaSemana*-1,@Fecha) AND datafimcontrato <= DATEADD(DD,7-@DiaSemana,@Fecha) ";
            SqlCeConnection conDataBaseF = new SqlCeConnection(constringF);
            SqlCeCommand cmdDataBaseF = new SqlCeCommand(QueryF, conDataBaseF);
            cmdDataBaseF.Parameters.Add("@Fecha", monthCalendar1.Value);
            try
            {
                SqlCeDataAdapter sda = new SqlCeDataAdapter();
                sda.SelectCommand = cmdDataBaseF;
                System.Data.DataTable dbdatasetF = new System.Data.DataTable();
                sda.Fill(dbdatasetF);
                BindingSource bSourceF = new BindingSource();
                bSourceF.DataSource = dbdatasetF;
                dataGridView1.DataSource = bSourceF;
                sda.Update(dbdatasetF);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
