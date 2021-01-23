        public TB_CLIENTE_CLI Get(int id)
        {
            using (PlanoTesteDataContext ctx = new PlanoTesteDataContext())
            {
                ctx.ObjectTrackingEnabled = false;
                return ctx.TB_CLIENTE_CLI.SingleOrDefault(n => n.ID == id);
            }
        }
        public void Save(TB_CLIENTE_CLI cliente)
        {
            using (PlanoTesteDataContext ctx = new PlanoTesteDataContext())
            {
                ctx.DeferredLoadingEnabled = false;
                ctx.TB_CLIENTE_CLI.Attach(cliente, true);
                ctx.SubmitChanges();
            }
        }
