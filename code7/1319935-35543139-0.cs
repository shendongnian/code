     public Bibliography GetBibliographies()
            {
                    Bibliography bibliography = new Bibliography();
                    bibliography.MyJournals = db.Journal.ToList();
                    bibliography.MyCases = db.Cases.ToList();
                    bibliography.MyBooks = db.Books.ToList();
                    bibliography.MyStatutes = db.Statutes.ToList();
                    return bibliography;
            }
           
