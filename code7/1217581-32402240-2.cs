    protected void btnGenerarInforme_Click(object sender, EventArgs e)
            {
                int numeroSemana = 0;
                int estadoOperacion = 0;
    
                Int32.TryParse(comboNumeroSemanas.SelectedValue.ToString(), out numeroSemana);
                Int32.TryParse(comboEstadoOperacion.SelectedValue.ToString(), out estadoOperacion);
    
                if (numeroSemana <= 0 || estadoOperacion <= 0)
                    return;
    
                lv.Controls.Clear();
                // Create an user control for each checked 
                foreach (var opcion in comboTipoOperacion.CheckedItems)
                {
                    // Get data
                    var datos = GetInforme(numeroSemana, Convert.ToInt32(opcion.Value), estadoOperacion);
    
                    var di = (DatosInforme)LoadControl("/UserControls/DatosInforme.ascx");                        
                    di.SetDataSource(datos);
                    lv.Controls.Add(di);
                    
                }
            }
