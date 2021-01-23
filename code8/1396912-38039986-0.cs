     private void button9_Click(object sender, EventArgs e)
            {
                if (dataGridView1.Rows.Count != 0 && dataGridView1.Rows != null)
                {        
    
                            Createe();              
            }
        ///////////////////////////////////////////////
            else
            {
                MessageBox.Show("Não há elementos para gerar a ficha de registro.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.funcionariosTableAdapter.Fill(this.cadastramentodbDataSet.Funcionarios);
                string constringF = @"Data Source=|DataDirectory|\cadastramentodb.sdf;Persist Security Info=False";
                string QueryF = "SELECT * FROM Funcionarios WHERE (status = @status and  idsetor = @idsetor and idempresa = @idempresa) ";
                SqlCeConnection conDataBaseF = new SqlCeConnection(constringF);
                SqlCeCommand cmdDataBaseF = new SqlCeCommand(QueryF, conDataBaseF);
                cmdDataBaseF.Parameters.Add("@status", SqlDbType.NVarChar).Value = comboBox1.Text;
                cmdDataBaseF.Parameters.Add("@idsetor", SqlDbType.NVarChar).Value = comboBox3.Text;
                cmdDataBaseF.Parameters.Add("@idempresa", SqlDbType.NVarChar).Value = comboBox2.Text;
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
        }
        public void Createe()
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            string vIDg = (row.Cells[0].Value.ToString());
            DataGridViewRow row2 = dataGridView1.SelectedRows[0];
            string vIDg2 = (row.Cells[1].Value.ToString());
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Documento do Word|*.docx";
            saveFileDialog1.Title = "Salvar";
            saveFileDialog1.FileName = "FICHA DE REGISTRO " + vIDg2 + "";
            if (DialogResult.OK == saveFileDialog1.ShowDialog())
            {
                string OutputFile = saveFileDialog1.FileName;
                if (OutputFile.Length > 0)
                {
                    var AssemblyPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    var caminho = "" + AssemblyPath + "\\Resources\\FICHAREG2.docx";
                    using (DocX document = DocX.Load(caminho))
                    {
                        // Replace text in this document.
                        string constring = @"Data Source=|DataDirectory|\cadastramentodb.sdf;Persist Security Info=False";
                        string Query = "SELECT * FROM Funcionarios WHERE (id = @id)";
                        SqlCeConnection conDataBase = new SqlCeConnection(constring);
                        SqlCeCommand cmdDataBase = new SqlCeCommand(Query, conDataBase);
                        cmdDataBase.Parameters.Add("@id", SqlDbType.NVarChar).Value = vIDg;
                        SqlCeDataReader myReader;
                        try
                        {
                            conDataBase.Open();
                            myReader = cmdDataBase.ExecuteReader();
                            while (myReader.Read())
                            {
                                string nomefuncs = myReader.GetString(1);
                                var nomefunc = nomefuncs.ToString();
                                document.ReplaceText("$$nomefunc$$", "" + nomefunc + "");
                                string numordems = myReader.GetString(82);
                                var numordem = numordems.ToString();
                                document.ReplaceText("$$numordem$$", "" + numordem + "");
                                string nummatriculas = myReader.GetString(83);
                                var nummatricula = nummatriculas.ToString();
                                document.ReplaceText("$$nummatricula$$", "" + nummatricula + "");
                                string nomepaifuncs = myReader.GetString(2);
                                var nomepaifunc = nomepaifuncs.ToString();
                                document.ReplaceText("$$nomepaifunc$$", "" + nomepaifunc + "");
                                string nomemaefuncs = myReader.GetString(3);
                                var nomemaefunc = nomemaefuncs.ToString();
                                document.ReplaceText("$$nomemaefunc$$", "" + nomemaefunc + "");
                                string paifuncnacios = myReader.GetString(4);
                                var paifuncnacio = paifuncnacios.ToString();
                                document.ReplaceText("$$paifuncnacio$$", "" + paifuncnacio + "");
                                string maefuncnacios = myReader.GetString(5);
                                var maefuncnacio = maefuncnacios.ToString();
                                document.ReplaceText("$$maefuncnacio$$", "" + maefuncnacio + "");
                                DateTime datanascs = myReader.GetDateTime(6);
                                var datanasc = datanascs.ToShortDateString();
                                document.ReplaceText("$$datanasc$$", "" + datanasc + "");
                                string idades = myReader.GetString(88);
                                var idade = idades.ToString();
                                document.ReplaceText("$$idade$$", "" + idade + "");
                                string funcnacios = myReader.GetString(7);
                                var funcnacio = funcnacios.ToString();
                                document.ReplaceText("$$funcnacio$$", "" + funcnacio + "");
                                string estadocivils = myReader.GetString(8);
                                var estadocivil = estadocivils.ToString();
                                document.ReplaceText("$$estadocivil$$", "" + estadocivil + "");
                                string localnascs = myReader.GetString(9);
                                var localnasc = localnascs.ToString();
                                document.ReplaceText("$$localnasc$$", "" + localnasc + "");
                                string ufnascs = myReader.GetString(10);
                                var ufnasc = ufnascs.ToString();
                                document.ReplaceText("$$ufnasc$$", "" + ufnasc + "");
                                string rgs = myReader.GetString(11);
                                var rg = rgs.ToString();
                                document.ReplaceText("$$rg$$", "" + rg + "");
                                string ctpssa = myReader.GetString(12);
                                var ctps = ctpssa.ToString();
                                document.ReplaceText("$$ctps$$", "" + ctps + "");
                                string ctpsss = myReader.GetString(13);
                                var ctpss = ctpsss.ToString();
                                document.ReplaceText("$$ctpss$$", "" + ctpss + "");
                                string reservistas = myReader.GetString(14);
                                var reservista = reservistas.ToString();
                                document.ReplaceText("$$reservista$$", "" + reservista + "");
                                string catreservistas = myReader.GetString(15);
                                var catreservista = catreservistas.ToString();
                                document.ReplaceText("$$catreservista$$", "" + catreservista + "");
                                string cpfs = myReader.GetString(16);
                                var cpf = cpfs.ToString();
                                document.ReplaceText("$$cpf$$", "" + cpf + "");
                                string tituloeleitors = myReader.GetString(17);
                                var tituloeleitor = tituloeleitors.ToString();
                                document.ReplaceText("$$tituloeleitor$$", "" + tituloeleitor + "");
                                string carteirasaudes = myReader.GetString(18);
                                var carteirasaude = carteirasaudes.ToString();
                                document.ReplaceText("$$carteirasaude$$", "" + carteirasaude + "");
                                string cbos = myReader.GetString(19);
                                var cbo = cbos.ToString();
                                document.ReplaceText("$$cbo$$", "" + cbo + "");
                                string cartmod19s = myReader.GetString(20);
                                var cartmod19 = cartmod19s.ToString();
                                document.ReplaceText("$$cartmod19$$", "" + cartmod19 + "");
                                string casadobrasileiros = myReader.GetString(21);
                                var casadobrasileiro = casadobrasileiros.ToString();
                                document.ReplaceText("$$casadobrasileiro$$", "" + casadobrasileiro + "");
                                string naturalizados = myReader.GetString(22);
                                var naturalizado = naturalizados.ToString();
                                document.ReplaceText("$$naturalizado$$", "" + naturalizado + "");
                                string filhosbrasileiross = myReader.GetString(23);
                                var filhosbrasileiros = filhosbrasileiross.ToString();
                                document.ReplaceText("$$filhosbrasileiros$$", "" + filhosbrasileiros + "");
                                string datachegadabrasils = myReader.GetString(25);
                                var datachegadabrasil = datachegadabrasils.ToString();
                                document.ReplaceText("$$datachegadabrasil$$", "" + datachegadabrasil + "");
                                string nregistrogerals = myReader.GetString(26);
                                var nregistrogeral = nregistrogerals.ToString();
                                document.ReplaceText("$$nregistrogeral$$", "" + nregistrogeral + "");
                                string nomeconjuges = myReader.GetString(27);
                                var nomeconjuge = nomeconjuges.ToString();
                                document.ReplaceText("$$nomeconjuge$$", "" + nomeconjuge + "");
                                string quantosfilhoss = myReader.GetString(24);
                                var quantosfilhos = quantosfilhoss.ToString();
                                document.ReplaceText("$$quantosfilhos$$", "" + quantosfilhos + "");
                                string enderecos = myReader.GetString(28);
                                var endereco = enderecos.ToString();
                                document.ReplaceText("$$endereco$$", "" + endereco + "");
                                string mudancaenderecos = myReader.GetString(29);
                                var mudancaendereco = nregistrogerals.ToString();
                                document.ReplaceText("$$mudancaendereco$$", "" + mudancaendereco + "");
                                string corfuncs = myReader.GetString(70);
                                var corfunc = corfuncs.ToString();
                                document.ReplaceText("$$corfunc$$", "" + corfunc + "");
                                string alturafuncs = myReader.GetString(71);
                                var alturafunc = alturafuncs.ToString();
                                document.ReplaceText("$$alturafunc$$", "" + alturafunc + "");
                                string pesofuncs = myReader.GetString(72);
                                var pesofunc = pesofuncs.ToString();
                                document.ReplaceText("$$pesofunc$$", "" + pesofunc + "");
                                string cabelosfuncs = myReader.GetString(73);
                                var cabelofunc = cabelosfuncs.ToString();
                                document.ReplaceText("$$cabelosfunc$$", "" + cabelofunc + "");
                                string olhosfuncs = myReader.GetString(74);
                                var olhosfunc = olhosfuncs.ToString();
                                document.ReplaceText("$$olhosfunc$$", "" + olhosfunc + "");
                                string sinaisfuncs = myReader.GetString(75);
                                var sinaisfunc = sinaisfuncs.ToString();
                                document.ReplaceText("$$sinaisfunc$$", "" + sinaisfunc + "");
                                string dependente1s = myReader.GetString(30);
                                var dependente1 = dependente1s.ToString();
                                document.ReplaceText("$$dependente1$$", "" + dependente1 + "");
                                string dependente2s = myReader.GetString(33);
                                var dependente2 = dependente2s.ToString();
                                document.ReplaceText("$$dependente2$$", "" + dependente2 + "");
                                string dependente3s = myReader.GetString(36);
                                var dependente3 = dependente3s.ToString();
                                document.ReplaceText("$$dependente3$$", "" + dependente3 + "");
                                string dependente4s = myReader.GetString(39);
                                var dependente4 = dependente4s.ToString();
                                document.ReplaceText("$$dependente4$$", "" + dependente4 + "");
                                string dependente5s = myReader.GetString(42);
                                var dependente5 = dependente5s.ToString();
                                document.ReplaceText("$$dependente5$$", "" + dependente5 + "");
                                string dependente6s = myReader.GetString(45);
                                var dependente6 = dependente6s.ToString();
                                document.ReplaceText("$$dependente6$$", "" + dependente6 + "");
                                string dependente1parentes = myReader.GetString(31);
                                var depentende1parente = dependente1parentes.ToString();
                                document.ReplaceText("$$dependente1parente$$", "" + depentende1parente + "");
                                string dependente2parentes = myReader.GetString(34);
                                var dependente2parente = dependente2parentes.ToString();
                                document.ReplaceText("$$dependente2parente$$", "" + dependente2parente + "");
                                string dependente3parentes = myReader.GetString(37);
                                var dependente3parente = dependente3parentes.ToString();
                                document.ReplaceText("$$dependente3parente$$", "" + dependente3parente + "");
                                string dependente4parentes = myReader.GetString(40);
                                var dependente4parente = dependente4parentes.ToString();
                                document.ReplaceText("$$dependente4parente$$", "" + dependente4parente + "");
                                string dependente5parentes = myReader.GetString(43);
                                var dependente5parente = dependente5parentes.ToString();
                                document.ReplaceText("$$dependente5parente$$", "" + dependente5parente + "");
                                string dependente6parentes = myReader.GetString(46);
                                var dependente6parente = dependente6parentes.ToString();
                                document.ReplaceText("$$dependente6parente$$", "" + dependente6parente + "");
                                string dependente1nascs = myReader.GetString(32);
                                var dependente1nasc = dependente1nascs.ToString();
                                document.ReplaceText("$$dependente1nasc$$", "" + dependente1nasc + "");
                                string dependente2nascs = myReader.GetString(35);
                                var dependente2nasc = dependente2nascs.ToString();
                                document.ReplaceText("$$dependente2nasc$$", "" + dependente2nasc + "");
                                string dependente3nascs = myReader.GetString(38);
                                var dependente3nasc = dependente3nascs.ToString();
                                document.ReplaceText("$$dependente3nasc$$", "" + dependente3nasc + "");
                                string dependente4nascs = myReader.GetString(41);
                                var dependente4nasc = dependente4nascs.ToString();
                                document.ReplaceText("$$dependente4nasc$$", "" + dependente4nasc + "");
                                string dependente5nascs = myReader.GetString(44);
                                var dependente5nasc = dependente5nascs.ToString();
                                document.ReplaceText("$$dependente5nasc$$", "" + dependente5nasc + "");
                                string dependente6nascs = myReader.GetString(47);
                                var dependente6nasc = dependente6nascs.ToString();
                                document.ReplaceText("$$dependente6nasc$$", "" + dependente6nasc + "");
                                string datacadpiss = myReader.GetString(48);
                                var datacadpis = datacadpiss.ToString();
                                document.ReplaceText("$$datacadpis$$", "" + datacadpis + "");
                                string piss = myReader.GetString(49);
                                var pis = piss.ToString();
                                document.ReplaceText("$$pis$$", "" + pis + "");
                                string nobancopiss = myReader.GetString(50);
                                var nobancopis = nobancopiss.ToString();
                                document.ReplaceText("$$nobancopis$$", "" + nobancopis + "");
                                string endpiss = myReader.GetString(51);
                                var endpis = endpiss.ToString();
                                document.ReplaceText("$$endpis$$", "" + endpis + "");
                                string bancopiss = myReader.GetString(52);
                                var bancopis = bancopiss.ToString();
                                document.ReplaceText("$$bancopis$$", "" + bancopis + "");
                                string agpiss = myReader.GetString(53);
                                var agpis = agpiss.ToString();
                                document.ReplaceText("$$agpis$$", "" + agpis + "");
                                DateTime dataentradas = myReader.GetDateTime(54);
                                var dataentrada = dataentradas.ToShortDateString();
                                document.ReplaceText("$$dataentrada$$", "" + dataentrada + "");
                                DateTime dataentradalongas = myReader.GetDateTime(54);
                                var dataentradalonga = dataentradalongas.ToLongDateString();
                                document.ReplaceText("$$dataentradalonga$$", "" + dataentradalonga + "");
                                DateTime dataregs = myReader.GetDateTime(55);
                                var datareg = dataregs.ToShortDateString();
                                document.ReplaceText("$$datareg$$", "" + datareg + "");
                                string ocupacaos = myReader.GetString(56);
                                var ocupacao = ocupacaos.ToString();
                                document.ReplaceText("$$ocupacao$$", "" + ocupacao + "");
                                string secaos = myReader.GetString(57);
                                var secao = secaos.ToString();
                                document.ReplaceText("$$secao$$", "" + secao + "");
                                string salarioinicials = myReader.GetString(58);
                                var salarioinicial = salarioinicials.ToString();
                                document.ReplaceText("$$salarioinicial$$", "" + salarioinicial + "");
                                string comissoess = myReader.GetString(59);
                                var comissoes = comissoess.ToString();
                                document.ReplaceText("$$comissoes$$", "" + comissoes + "");
                                string tarefas = myReader.GetString(60);
                                var tarefa = tarefas.ToString();
                                document.ReplaceText("$$tarefa$$", "" + tarefa + "");
                                string formapagamentos = myReader.GetString(61);
                                var formapagamento = formapagamentos.ToString();
                                document.ReplaceText("$$formapagamento$$", "" + formapagamento + "");
                                string eoptantes = myReader.GetString(62);
                                var eoptante = eoptantes.ToString();
                                document.ReplaceText("$$eoptante$$", "" + eoptante + "");
                                DateTime dataopcaos = myReader.GetDateTime(63);
                                var dataopcao = dataopcaos.ToShortDateString();
                                document.ReplaceText("$$dataopcao$$", "" + dataopcao + "");
                                DateTime dataretratacaos = myReader.GetDateTime(64);
                                var dataretratacao = dataretratacaos.ToShortDateString();
                                document.ReplaceText("$$dataretratacao$$", "" + dataretratacao + "");
                                string bancodepositarios = myReader.GetString(69);
                                var bancodepositario = bancodepositarios.ToString();
                                document.ReplaceText("$$bancodepositario$$", "" + bancodepositario + "");
                                string hentradas = myReader.GetString(65);
                                var hentrada = hentradas.ToString();
                                document.ReplaceText("$$hentrada$$", "" + hentrada + "");
                                string halmocos = myReader.GetString(66);
                                var halmoco = halmocos.ToString();
                                document.ReplaceText("$$halmoco$$", "" + halmoco + "");
                                string hsaidas = myReader.GetString(67);
                                var hsaida = hsaidas.ToString();
                                document.ReplaceText("$$hsaida$$", "" + hsaida + "");
                                string dsrs = myReader.GetString(68);
                                var dsr = dsrs.ToString();
                                document.ReplaceText("$$dsr$$", "" + dsr + "");
                                DateTime datafimcontratos = myReader.GetDateTime(78);
                                var datafimcontrato = datafimcontratos.ToShortDateString();
                                document.ReplaceText("$$datafimcontrato$$", "" + datafimcontrato + "");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        document.SaveAs(OutputFile);
                        MessageBox.Show("Ficha de Registro de "+vIDg2+" criada com sucesso!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    } // Release this document from memory.
                }
            }
            else
            {
            }
            
          
        }
