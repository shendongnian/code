    protected void repProducts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                DataGrid dg = (DataGrid)e.Item.FindControl("dgProduct");
                if (dg != null)
                {
                    for (int i = 0; i < dg.Columns.Count; i++)
                    {
                        if (dg.Columns[i].HeaderText == String.Empty)
                        {
                            if (System.Globalization.CultureInfo.CurrentCulture.Name == "en-US")
                            {
                                switch (productIDs[numProductID])
                                {
                                    case 264:
                                        dg.Columns[i].HeaderText = "TL Price Per Pack";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                    case 266:
                                        dg.Columns[i].HeaderText = "TL Price Per Pack";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                    case 296:
                                        dg.Columns[i].HeaderText = "TL Price Per Pack";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                    default:
                                        dg.Columns[i].HeaderText = "TL Price/<br/>1000 sq ft";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                }
                            }
                            if (System.Globalization.CultureInfo.CurrentCulture.Name == "fr-FR")
                            {
                                switch (productIDs[numProductID])
                                {
                                    case 265:
                                        dg.Columns[i].HeaderText = "TL Prix Par Paquet";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                    case 267:
                                        dg.Columns[i].HeaderText = "TL Prix Par Paquet";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                    case 297:
                                        dg.Columns[i].HeaderText = "TL Prix Par Paquet";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                    default:
                                        dg.Columns[i].HeaderText = "Prix TL/1000<br/>pieds carrés";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                }
                            }
                            if (System.Globalization.CultureInfo.CurrentCulture.Name == "es-ES")
                            {
                                switch (productIDs[numProductID])
                                {
                                    case 375:
                                        dg.Columns[i].HeaderText = "TL Precio Por Paquete";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                    case 377:
                                        dg.Columns[i].HeaderText = "TL Precio Por Paquete";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                    case 405:
                                        dg.Columns[i].HeaderText = "TL Precio Por Paquete";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                    default:
                                        dg.Columns[i].HeaderText = "Precio de TL por 1000 pies cuadrados";
                                        dg.DataBind();
                                        numProductID++;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                litError.Text = Utility.FormatErrorMessage(ex);
            }
        }
