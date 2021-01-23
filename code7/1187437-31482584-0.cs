			static void Main() {
				var pagos = new List<PagoInfoDBO>();
        		var montosDebitoCredito  = new List<ComprobanteMontoDBO>();
		        
        		var query = pagos.Cast<MontoAPagar>().Concat(montosDebitoCredito.Cast<MontoAPagar>())
        			.GroupBy(item=> item.IdComprobante)
        			.Select(g=> new {
        			        	IdComprobante = g.Key, 
        			        	SortedByIdMovimiento = g.OrderBy(item=> item.IdMovimiento).ToArray()
        			        }).ToArray();
		
