    private asynch Task<DTOVObs> TransFormAaretsGang(DTOAaretsGang aaretsGang)
        {
            using (var artservice = new ArtService())
            {
                return artservice.GetVArtFormArt(new DTOArt() {ART_ID = aaretsGang.ART_ID}).ContinueWith(t =>
                {
                    dtovObs.Familie_id = t.Result.Familie_id;
                    dtovObs.Gruppe_id = t.Result.Gruppe_id;
                    dtovObs.ART_ID = t.Result.ART_ID;
                    if (aaretsGang.Dato != null) dtovObs.Aarstal = aaretsGang.Dato.Value.Year;
                    return dtovObs;
                });
            }
        }
