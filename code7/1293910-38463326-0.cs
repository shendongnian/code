    private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
                codigo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
    
                Piso formPiso = new Piso();
    
                var consultaPisoAlquiler = from piso in contexto.pisosAlquiler
                                           where piso.codigo == codigo
                                           select new
                                           {
                                               fotos = piso.fotos.Split(','),
                                               zona = piso.zona,
                                               mm = piso.mm,
                                               descripcion = piso.descripcion,
                                               precio = piso.precio,
                                               estado = piso.estado
                                           };
    
                formPiso.txtCodigo.Text = codigo.ToString();
                formPiso.txtDescripcion.Text = consultaPisoAlquiler.First().descripcion.ToString();
                formPiso.txtEstado.Text = consultaPisoAlquiler.First().estado.ToString();
                formPiso.txtMm.Text = consultaPisoAlquiler.First().mm.ToString();
                formPiso.txtPrecio.Text = consultaPisoAlquiler.First().precio.ToString();
                formPiso.txtZona.Text = consultaPisoAlquiler.First().zona.ToString();
    
                formPiso.DGVPisoFotos.AutoGenerateColumns = false;
                formPiso.DGVPisoFotos.Columns.Clear();
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Width = 230;
                img.HeaderText = "Fotos";
                formPiso.DGVPisoFotos.Columns.Add(img);
                int i = 0;
                foreach (var foto in consultaPisoAlquiler.First().fotos)
                {
                    formPiso.DGVPisoFotos.Rows.Add();
                    string path = "E:/WorkSpaces/MVS/ProyectoJoseph/" + foto;
                    Bitmap image = (Bitmap)Image.FromFile(path);
                    Bitmap imageRS = new Bitmap(image, new Size(230, 230));
                    formPiso.DGVPisoFotos[0, i].Value = imageRS;
                    formPiso.DGVPisoFotos.Rows[i].Height = 230;
                    i++;
                }
    
                formPiso.ShowDialog();
    }
