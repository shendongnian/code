            var root = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<SchoolSubject>>(json);
            foreach (var subject in root)
            {
                Console.WriteLine(subject.Subject);
                foreach (var item in subject.AppScores)
                {
                    Console.WriteLine("season: {0}, year: {1}", item.Season, item.year);
                }
            }
