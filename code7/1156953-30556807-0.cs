                List<SavedQuote> savedQuotes = new List<SavedQuote>();
                List<NoteOnSite> noteOnSites = new List<NoteOnSite>();
                var results = from savedQuote in savedQuotes.OrderBy(x => x.DateOfAdding)
                              join noteOnSite in noteOnSites.OrderBy(x => x.DateOfAdding)
                              on savedQuote.ID equals noteOnSite.ID
                              select new { saved = savedQuotes, note = noteOnSites };​
