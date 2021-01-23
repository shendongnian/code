            public DateTime? GetModificationDate(int employeeID)
            {
                var session = SapHelper.GetActiveSession();
                Console.WriteLine("Recherche de la measure [A5 ou A6] avec un motif 90...");
                var window = session.BeginTransaction("PA20", "Afficher données de base personnel");
                window.FindByName<GuiCTextField>("RP50G-PERNR").Text = employeeID.ToString();
                window.FindByName<GuiCTextField>("RP50G-CHOIC").Text = "Mesures  (0000)";
                window.FindByName<GuiCTextField>("RP50G-SUBTY").Text = null;
                window.FindByName<GuiButton>("btn[20]").Press(); // list view
                if (window.Text == "Afficher données de base personnel")
                {
                    Console.WriteLine(">> " + window.FindByName<GuiStatusbar>("sbar").Text);
                    return null;
                }
                /*  Index Type          Title             Tooltip             
                    0     GuiTextField  Début             Date de début       
                    1     GuiTextField  Fin               Date de fin         
                    2     GuiCTextField Mes.              Catégorie de mesure 
                    3     GuiTextField  Dés. cat. mesure  Dés. cat. mesure    
                    4     GuiCTextField MotMe             Motif mesure        
                    5     GuiTextField  Dés. motif mesure Dés. motif mesure   
                    6     GuiCTextField Client            Statut propre client
                    7     GuiCTextField Activité          Statut d'activité   
                    8     GuiCTextField Paiement          Statut paiement part */
                var result = window.FindByName<GuiTableControl>("MP000000TC3000").AsEnumerable()
                    .Select(x => new
                    {
                        Start = x.GetText(0),
                        Category = x.GetCText(2),
                        CategoryText = x.GetText(3),
                        Reason = x.GetCText(4),
                        ReasonText = x.GetText(5),
                    })
                    .Where(x => (x.Category == "A5" || x.Category == "AG") && x.Reason == "90")
                    .FirstOrDefault();
                if (result == null)
                {
                    Console.WriteLine(">> aucune measure [A5 ou A6] avec un motif 90 trouvée");
                    return null;
                }
                else
                {
                    Console.WriteLine(">> {0}:[{1}]{2} [{3}]{4}",
                        result.Start, result.Category, result.Category, result.Reason, result.ReasonText);
                    return DateTime.ParseExact(result.Start, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                }
            }
