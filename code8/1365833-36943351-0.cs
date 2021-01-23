    //Generate CSV Files for each item in the Listview
        CsvFileDescription outpCsvFileDescription = new CsvFileDescription
        {
            SeparatorChar = ',',
            FirstLineHasColumnNames = true
        };
        for (int i = 0; i < listView.Items.Count; i++)
        {
            var infoEcheances = from f in db.F_ECHEANCES
                                where f.ECH_Intitule == listView.Items[i].f.ECH_Intitule
                                select new { f.ECH_Intitule, f.ECH_DateEch, f.CG_Num, f.ECH_Piece, f.ECH_RefPiece, f.ECH_Montant, f.ECH_Libelle };
            CsvContext cc = new CsvContext();
            string myPath = @"C:\Users\DefaultAccount\Desktop\Projet Top Of Travel\FichiersCSV\";
            string filename = string.Format("Facture{0}.csv", i);
            string finalPath = System.IO.Path.Combine(myPath, filename);
            cc.Write(infoEcheances, finalPath, outpCsvFileDescription);
        }
