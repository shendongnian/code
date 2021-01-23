    dossiers = dossiers.Where(d => 
               d.Defendeurs.Any(DossierTiers => DossierTiers.Tiers != null && 
               DossierTiers.Tiers.TiersLiesEnfantsActifs != null && 
               DossierTiers.Tiers.TiersLiesEnfantsActifs.Any(
                    TiersLie => TiersLie.TiersEnfant != null && 
                    TiersLie.TiersEnfant.AdressePrincipale != null && 
                    TiersLie.TiersEnfant.AdressePrincipale.Adresse.CodePostal != null && 
                    TiersLie.TiersEnfant.AdressePrincipale.Adresse.CodePostal.Contains("45"))))
              .ToLi‌​st();
