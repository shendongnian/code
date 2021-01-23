    DbFactory poli = new DbFactory();
    using (ISession session = poli.OpenSession()) {
      test = poli.getPoliceData(session);
      skader = poli.getSkadeData(session);
    }
