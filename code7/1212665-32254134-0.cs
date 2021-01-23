    myConfiguration = new Configuration();
    myConfiguration.Configure();
    mysessionFactory = myConfiguration.BuildSessionFactory();
    mySession = mysessionFactory.OpenSession();
    using (mySession.BeginTransaction())
    {
        Dossier dossier = new Dossier();
        dossier.Compagnie_assurance = "Compagnie1";
        dossier.Agent_assurance = "Agent1";
        dossier.Date_accident = DateTime.Now;
        dossier.Date_expertise = DateTime.Now;
        dossier.Date_mission = DateTime.Now; 
        IList<Image> listImages = new IList<Image>();
        for (int i = 0; i <nbImage ; i++)
        {
            Image img = new Image();   
            img.ID = i;
            img.url = "";
            img.image = "";
            img.Dossier = dossier;
            listImages.Add(img);
        }      
        dossier.listImages = listImages; 
        mySession.Save(dossier);
        mySession.Transaction.Commit();
    }
