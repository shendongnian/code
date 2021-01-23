    [HttpPost]
    public ActionResult ActionNumber2(ParentModel parentViewModel)
    {
        if (parentViewModel != null)
        {
            List<ObjetTransfert> listeParentObjetsTransferts = new List<ObjetTransfert>();
            ActionNumber2 actionNumber2;
            ConvertParentModelToParentBd(parentViewModel, listeParentObjetsTransferts);
            _confidential.CCP(listeParentObjetsTransferts , out resultatC,
                Enums.E.T);
            //Enregistrer d'abord le resultat en Bd
            resultatC.IdentifiantRC = new Guid().ToString();
            _resultatCS.Create(resultatC);
            Session["ID"] = resultatC.Id;
            UserInformationViewModel parentViewModel= parentViewModel.UserInformationViewModel;
            var client = new MongoClient("mongodb://localhost:27017");
            var objDatabase = client.GetDatabase("Test");
            var collection = objDatabase.GetCollection<BsonDocument>("UsersInformations");
            BsonDocument objDocument = new BsonDocument {
            {"Nom",info.NomUser},
            {"Prenom",info.PrenomUser},
            {"Email",info.EmailUser},
            {"Telephone",info.TelephoneUser},               
            };
            collection.InsertOne(objDocument);
            return View();
        }
        return null;
    }
