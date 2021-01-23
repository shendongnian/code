    [HttpPost]
    public ActionResult Modifier(DocFormViewModel viewModel){
        dal.ModifierType(viewModel.Doc.Id, viewModel.SelectedTypeString);
        dal.AjouterDocumentAReferentiel(viewModel.Doc.Id, viewModel.SelectedReferentielId); // English : AddDocumentToReferentiel(id_Document, id_Referentiel)
        return RedirectToAction("Index", "Accueil");
    }
