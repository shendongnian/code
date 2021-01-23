            int indice = 0; 
            int rimosse = 0;
            int aggiornate = 0;
            int aggiunte = 0;
            int righeDGV1 = dataGridView1.Rows.Count;
            int righeDGV2 = dataGridView2.Rows.Count;
            for (int i = 0; i < righeDGV1; i++) //Loop in DGV1
            {
                int righedaSaltare = 0;
                string controlloODL = dataGridView1["ODL", indice].Value.ToString();
                for (int j = 0; j < righeDGV2; j++) //Check if the row in DGV1 is present in DGV2
                {
                    if (controlloODL == dataGridView2["ODL", j].Value.ToString()) 
                    {
                        //If true increase the counters skipline and update, then update the value of the row in DGV1
                        righedaSaltare++;
                        aggiornate++;
                        dataGridView1["Qta ordine", indice].Value = dataGridView2["Qta ordine", j].Value;
                        dataGridView1["Qta stampata", indice].Value = dataGridView2["Qta stampata", j].Value;
                        dataGridView1["Qta da stampare", indice].Value = dataGridView2["Qta da stampare", j].Value;
                        dataGridView1["Warehouse date", indice].Value = dataGridView2["Warehouse date", j].Value;
                    }
                }
                if (righedaSaltare == 0)
                    //If the row in DGV1 isn't in DGV2 remove it 
                {
                    dataGridView1.Rows.RemoveAt(indice);
                    rimosse++;
                }
                if (righedaSaltare > 0)
                {
                    //If the row in DGV1 is present in DGV2, check the next line in DGV1
                    indice++;
                }
            } 
            int nuovoindice = 0;
            int righeDGV1nuovo = dataGridView1.RowCount;
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                //Loop in DGV2
                int righedaSaltare = 0;
                string controlloNuovoODL = dataGridView2["ODL", nuovoindice].Value.ToString();
                for (int k = 0; k < dataGridView1.Rows.Count; k++)
                {
                    //Check if the row in DGV2 is present in DGV1
                    if (controlloNuovoODL == dataGridView1["ODL", k].Value.ToString())
                    {
                        //If true increase the counter skipline
                        righedaSaltare++;
                    }
                }
                if (righedaSaltare == 0)
                {
                    //If the row in DGV2 isn't in DGV1, add it to datatable, increase the counter update and re-sort the DGV1
                    DataRow nuovaRigaODL = datiDataSet.NewRow();
                    nuovaRigaODL["Giorni utili"] = dataGridView2["Giorni utili", nuovoindice].Value.ToString();
                    nuovaRigaODL["Giorni necessari"] = dataGridView2["Giorni necessari", nuovoindice].Value.ToString();
                    nuovaRigaODL["Sequenza"] = dataGridView2["Sequenza", nuovoindice].Value.ToString();
                    nuovaRigaODL["Montato"] = dataGridView2["Montato", nuovoindice].Value;
                    nuovaRigaODL["Cella"] = dataGridView2["Cella", nuovoindice].Value.ToString();
                    nuovaRigaODL["Data inizio stampaggio"] = dataGridView2["Data inizio stampaggio", nuovoindice].Value.ToString();
                    nuovaRigaODL["Warehouse date"] = dataGridView2["Warehouse date", nuovoindice].Value.ToString();
                    nuovaRigaODL["ODL"] = dataGridView2["ODL", nuovoindice].Value.ToString();
                    nuovaRigaODL["Item number"] = dataGridView2["Item number", nuovoindice].Value.ToString();
                    nuovaRigaODL["Qta ordine"] = dataGridView2["Qta ordine", nuovoindice].Value.ToString();
                    nuovaRigaODL["Qta stampata"] = dataGridView2["Qta stampata", nuovoindice].Value.ToString();
                    nuovaRigaODL["Qta da stampare"] = dataGridView2["Qta da stampare", nuovoindice].Value.ToString();
                    nuovaRigaODL["Pressa"] = dataGridView2["Pressa", nuovoindice].Value.ToString();
                    nuovaRigaODL["Trimming"] = dataGridView2["Trimming", nuovoindice].Value.ToString();
                    nuovaRigaODL["Materiale"] = dataGridView2["Materiale", nuovoindice].Value.ToString();
                    nuovaRigaODL["Stampo"] = dataGridView2["Stampo", nuovoindice].Value.ToString();
                    nuovaRigaODL["Diametro"] = dataGridView2["Diametro", nuovoindice].Value.ToString();
                    nuovaRigaODL["Impr Disp"] = dataGridView2["Impr Disp", nuovoindice].Value.ToString();
                    nuovaRigaODL["Peso pezzo (grammi)"] = dataGridView2["Peso pezzo (grammi)", nuovoindice].Value.ToString();
                    nuovaRigaODL["Peso materozza (grammi)"] = dataGridView2["Peso materozza (grammi)", nuovoindice].Value.ToString();
                    nuovaRigaODL["Consumo materiale (Kg)"] = dataGridView2["Consumo materiale (Kg)", nuovoindice].Value.ToString();
                    aggiunte++;
                    datiDataSet.Rows.Add(nuovaRigaODL);
                    datiDataSet.DefaultView.Sort = "Warehouse date";
                    i--;
                }
                if (righedaSaltare > 0)
                {
                    //If the row exist in DGV1, check the next row in DGV2
                    nuovoindice++;
                }
            }
