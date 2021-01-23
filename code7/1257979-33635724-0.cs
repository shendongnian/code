    DataTable dtRel = new DataTable();
    var queryRows = (from dRow in dtRel.AsEnumerable()
    					select new 
    					{ 
    					   dtGeracao = dRow.Field<DateTime>("DT_GERACAO"),
                           binario   = dRow.Field<byte[]>("BL_RELATORIO")
    					});		
