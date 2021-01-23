     class persistence
     {
        ISharedPreferences prefs;
        ISharedPreferencesEditor editor;
        public persistence(Context cont)
        {
            prefs = PreferenceManager.GetDefaultSharedPreferences(cont);
            editor = prefs.Edit();
        }
        public void store(List<articulo> articulos)
        {
            string raw = JsonConvert.SerializeObject(articulos);
            editor.PutString("articulos", raw);
            editor.Commit();
        }
        public List<articulo> recover()
        {
            string raw = prefs.GetString("articulos", null);
            List<articulo> lista;
            if (raw == null)
                lista = new List<articulo>();
            else
                lista = JsonConvert.DeserializeObject<List<articulo>>(raw);
            return lista;
        }
     }
