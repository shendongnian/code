            var mergedMesures = mesures
                .GroupBy(_ => _.Commentaires)
                .Select(_ => new HistoMesures
                {
                    Debut = _.Min(item => item.Debut),
                    Fin = _.Max(item => item.Fin),
                    Commentaires = _.Key
                });
