    public void TabelaFuncionario()
        {
            try
            {
                BDfuncionarios = new DataTable();
                string cmd = "your select";
                var adpt = fConexao.GetDataAdapter(cmd);
                BDfuncionarios.Clear();
                adpt.Fill(BDfuncionarios);
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }
        public void BotaoFuncionario()
        {
            try
            {
                TabelaFuncionario();
                PosXartigo = 1;
                PosYartigo = 1;
                //Apagar o painel todo
                panel2.Controls.Clear();
                foreach (DataRow row in BDfuncionarios.Rows)
                {
                    int posicaoX = ((PosXartigo - 1) * Gap_Xartigo) + xInicial + (Largura_BotaoArtigo * (PosXartigo - 1));
                    if (posicaoX > maximoxArtigo)
                    {
                        PosYartigo++; PosXartigo = 1;
                    }
                    else
                    {
                        PosXartigo = PosXartigo != 1 ? PosXartigo++ : 1;
                    }
                    int PontoX = ((PosXartigo - 1) * Gap_Xartigo) + xInicial + (Largura_BotaoArtigo * (PosXartigo - 1));
                    int PontoY = ((PosYartigo - 1) * Gap_Yartigo) + yInicial + (Altura_BotaoArtigo * (PosYartigo - 1));
                    Button bt1 = new Button();
                    bt1.Location = new Point(PontoX, PontoY);
                    Mo mo = new Mo();
                    mo.codmo = (int)row["Var1"];
                    mo.nome_func = (string)row["Var2"];
                    
                    bt1.Name = "Botao" + NBotoes.ToString();
                    bt1.Height = Altura_BotaoArtigo;
                    bt1.Width = Largura_BotaoArtigo;
                    bt1.BackColor = Color.Tan;
                    bt1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
                    bt1.ForeColor = Color.Black;
                    bt1.Text = mo.nome_func;
                    bt1.Tag = mo;
                    bt1.FlatStyle = FlatStyle.Popup;
                    bt1.Click += btFuncionario_click;
                    panel2.Controls.Add(bt1);
                    NBotoes++;
                    PosXartigo++;
                }
            }
            catch (Exception r)
            {
                MessageBox.Show(r.Message);
            }
        }
