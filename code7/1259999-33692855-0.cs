    public SqlConnection connect(String user, String password, String BD)
        {
            connectionSql = new SqlConnection(
                "user id=" + user + ";" +
                "password=" + password + ";" +
                "Server=" + BD + ";" +
                "Database=****;" +
                "Connection timeout=30"
                );
            try
            {
                connectionSql.Open();
                MessageBox.Show("Ligação estabelecida com o Servidor! ", "Ligação");
                return connectionSql;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Falhou a ligação!", "Ligação" + ex.Message);
                return null;
            }
        }
        //Metodo para inserir fornecedor na base dados.
        public void inserirFornecedor(string codigo, string nome, string entrega, int qos, int tsq, int qtd)
        {
            SqlConnection conn = connect(user, password, BD);
            if(conn==null) return;//Cannot connect to DB
            commandSql = new SqlCommand("INSERT INTO supplierschedule VALUES(@codigo,@nome,@entrega,@qos,@tsq,@qtd)", conn);
            commandSql.Parameters.AddWithValue("@codigo", codigo);
            commandSql.Parameters.AddWithValue("@nome", nome);
            commandSql.Parameters.AddWithValue("@entrega", entrega);
            commandSql.Parameters.AddWithValue("@qos", qos);
            commandSql.Parameters.AddWithValue("@tsq", tsq);
            commandSql.Parameters.AddWithValue("@qtd", qtd);
            commandSql.ExecuteNonQuery();
        }
