    public List<PainelChamados> ListarOrdem()
            {
                using (SistemaContext db = new SistemaContext())
                {      
                    var query = db.Chamado
                        .Where(c => (c.Situacao != Chamado.Esituacao.Concluido && c.Id_Agente != null))
                        .GroupBy(e => new { e.Id_Agente})
                        .Select(lg => new PainelChamados
                        {
                            CodAgente = lg.Key.Id_Agente,
                            Qtde = lg.Count()
                        });
    
                    UsuarioData ud = new UsuarioData();
                    List<PainelChamados> Lista = new List<PainelChamados>();
    
                    foreach (var item in query)
                    {
                        Lista.Add(new PainelChamados
                        {
                            CodAgente = item.CodAgente,
                            Agente = item.CodAgente == null ? string.Empty : ud.GetAgenteId(item.CodAgente),
                            Qtde = item.Qtde
                        });
                    }
                    return Lista;              
                }
            }
