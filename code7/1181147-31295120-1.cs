        private const string NUMERO_DE_MEDICOS = "Numero de Medicos";
        private const string MEDICOS_VISITADOS = "Medicos Visitados";
        protected void MergeGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var cell0 = e.Row.Cells[0].Text;
                if ((cell0 == NUMERO_DE_MEDICOS) || (cell0 == MEDICOS_VISITADOS))
                {
                    e.Row.BackColor = System.Drawing.Color.Aqua;
                }
            }
        }
