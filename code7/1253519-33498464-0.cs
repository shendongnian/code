      public bool InsertBatch(System.Collections.Generic.List<ParamDbLIST> dados, string tabela)
        {
            if (dados.Count == 0)
                return true;
            string campos = "";
            dados[0].ForEach(delegate(ParamDB p)
            {
                campos += (campos == "" ? "" : ", ") + "@" + p.sNOME + "#N#";
            });
            bool resultado = true;
            //Insere de 999 a 999, que é o máximo q o sql server permite por vez
            //Maximo de 2000 parametros
            int k = 0;
            while (k < dados.Count)
            {
                this.sql = new StringBuilder();
                List<String> vals = new List<string>();
                ParamDbLIST parametros_insert = new ParamDbLIST();
                int c_sqls = 0;
                int c_parametros = 0;
                while (k < dados.Count && c_sqls < 1000 && c_parametros < 1900)
                {
                    c_sqls++;
                    vals.Add("(" + campos.Replace("#N#", c_sqls.ToString()) + ")");
                    foreach (ParamDB p in dados[k])
                    {
                        p.sNOME += c_sqls.ToString();
                        parametros_insert.Add(p);
                        c_parametros++;
                    }
                    k++;
                }
                this.sql.Append("INSERT INTO " + tabela + "(" + campos.Replace("#N#", String.Empty).Replace("@", String.Empty) + ") VALUES " + String.Join(",", vals));
                resultado = resultado && this.RunSQL(sql.ToString(), parametros_insert);
            }
          
            return resultado;
        }
 
    public class ParamDbLIST : System.Collections.ObjectModel.Collection<ParamDB>
    {/*I have other stuff here, but this will work*/}
       public class ParamDB
    {
        public string sNOME { get; set; }
        public Object sVALOR { get; set; }}
