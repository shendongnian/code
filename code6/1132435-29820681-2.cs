    string pPod = null;
    using (var cont = DALProvider.CreateEntityContext())
            {
            
                var query =
                (from cliente in cont.T020_CLIENTI 
                from sito
                in cont.T021_SITI
                    .Where(s => s.ID_CLIENTE == cliente.ID_CLIENTE)
                    .DefaultIfEmpty()
                from relStrumenti
                in cont.T520_REL_STRUMENTI_SITI
                    .Where(s => s.ID_SITO == sito.ID_SITO && (s.COD_STUMENTO == pPod || pPod == null))
                    .DefaultIfEmpty()
                select new
                {
                    clienteRec = cliente,
                    sitoRec = sito,
                    relStrumentiRec = relStrumenti
                }).Distinct();
                if (!string.IsNullOrEmpty(aiFiltro.RAGIONE_SOCIALE))
                    query = query.Where(i => i.clienteRec.RAGIONE_SOCIALE.ToUpper().Contains(aiFiltro.RAGIONE_SOCIALE.ToUpper()));
                var vRes = (from clienteDef in query
            
                select new ClienteFiltrato
                {
                    RAGIONE_SOCIALE = clienteDef.clienteRec.RAGIONE_SOCIALE,
                    ID_CLIENTE = clienteDef.clienteRec.ID_CLIENTE,
                    COD_STRUMENTO = clienteDef.relStrumentiRec.COD_STUMENTO,
                    DATA_DA = clienteDef.relStrumentiRec.DA_DATA,
                    DATA_A = clienteDef.relStrumentiRec.A_DATA
                }).Distinct() ;
                return vRes.AsQueryable();
            }
