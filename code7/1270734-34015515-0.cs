    public bool IsValidDossier(Dossier d)
    {
        return d != null 
               && d.Defendeurs.Any(DossierTiers => 
                  DossierTiers.Tiers != null 
                  && DossierTiers.Tiers.TiersLiesEnfantsActifs != null 
                  && DossierTiers.Tiers.TiersLiesEnfantsActifs.Any(TiersLie =>       
                         TiersLie.TiersEnfant != null 
                         && TiersLie.TiersEnfant.AdressePrincipale != null 
                         && TiersLie.TiersEnfant.AdressePrincipale.Adresse.CodePostal != null;
    }
    public bool DossierMatchesPostalCode(Dossier d, string codePostal)
    {
        return d.Defendeurs.Any(dt => dt.Tiers.TiersLiesEnfantsActifs.Any(tl => tl.TiersEnfant.AdressePriincipal.Adresse.CodePostal.Contains(codePostal);
    }
