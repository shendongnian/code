            public Chart GetGrafico(int dias, int idDepartamento, int idPgto)
        {
            try
            {
                int idEmpresa = login.GetUsuario(System.Web.HttpContext.Current.User.Identity.Name).IdEmpresa;
                DateTime inicial = DateTime.Today.Date;
                DateTime final = inicial.AddDays(dias);
                var grafico = service.GetGrafico(inicial, final, idEmpresa, idDepartamento, idPgto);
                Chart myChart = new Chart(800, 600)
                    .AddTitle("Vencimentos futuros")
                    .AddSeries(
                    name: "Vencimentos",
                    xValue: grafico.Select(x => x.Dia).ToArray(),
                    yValues: grafico.Select(x => x.Valor).ToArray()).Write();                 
                return myChart;
            }
            catch (Exception)
            {
                throw;
            }
        }
