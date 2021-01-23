            var indicators = db.Sses
                .GroupBy(x => x.Estado)
                .Select(
                    delegate(YOUR_TYPE x)
                    {
                        var ivm = new IndicatorViewModel
                        {
                            Count = x.Count(),
                            IndicatorType = x.Key.ToString(),
                            Total = x.Count()/total
                        };
                        switch (x.Key)
                        {
                            case "bg-red":
                                ivm.IndicatorClass = EstadoServicio.Nuevo;
                                //ivm.IonClass = 
                                break;
                            
                            // etc.
                        }
                        return ivm;
                    }
                );
