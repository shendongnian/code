                if (PuntenCollectie.IndexOf(Punt).Equals(0))
                {
                    cr.BeginFigure(Punt, false, false);
                }
                else
                {
                    cr.LineTo(Punt, false, false);
                }
