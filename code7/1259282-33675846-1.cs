                if (PuntenCollectie.IndexOf(Punt).Equals(0))
                {
                    cr.BeginFigure(Punt, true, false);
                }
                else
                {
                    cr.LineTo(Punt, true, false);
                }
