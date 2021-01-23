                var db = new ApplicationDbContext();
            int total = db.Sses.Count();
            var indicators = db.Sses
            .GroupBy(x => x.Estado)
            .Select(
            delegate(IGrouping<EstadoServicio,Ss> x)
            {
                var ivm = new IndicatorViewModel
                {
                    Count = x.Count(),
                    IndicatorType = x.Key.ToString(),
                    Total = total
                };
                switch (x.Key)
                {
                    case EstadoServicio.Nuevo:
                        ivm.IndicatorClass = "bg-red";
                        ivm.IconClass = "fa-bookmark-o";
                        break;
                    case EstadoServicio.Proceso:
                        ivm.IndicatorClass = "bg-yellow";
                        ivm.IconClass = "fa-bell-o";
                        break;
                    case EstadoServicio.Aprobación:
                        ivm.IndicatorClass = "bg-aqua";
                        ivm.IconClass = "fa-calendar-o";
                        break;
                    default:
                        ivm.IndicatorClass = "bg-green";
                        ivm.IconClass = "fa-heart-o";
                        break;
                }
                return ivm;
            }
    );
