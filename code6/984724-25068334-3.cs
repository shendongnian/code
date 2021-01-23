            //repository with the query
            var repositorio = new Repositorios.InformeMensualController();
            //capture ajax
            string canal = String.Join("", Request.Form.GetValues("canal"));
            string auxAnio = String.Join("", Request.Form.GetValues("anio"));
            int anio = Convert.ToInt32(auxAnio);
            string auxVendedorCodigo = String.Join("", Request.Form.GetValues("vendedorsigla"));
            int vendedorCodigo = Convert.ToInt32(auxVendedorCodigo);
            //set up data
            var data = repositorio.CargaDatos(canal, anio, vendedorCodigo);
            //Transformación a JSON y Datatables JS.
            var totalDatos = data.Count();
            var jsonData = Json(new {
                iTotalDisplayRecords = totalDatos,
                iTotalRecords = totalDatos,
                aaData = data});
            return jsonData;
