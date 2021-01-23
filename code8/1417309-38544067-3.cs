    public Dictionary<int, AuthorData> GetAuthorData(int startYear, int endYear)
    {
        var authorData = new Dictionary<int, AuthorData>();
    
        foreach (var paper in Papers.Where(p => p.Year >= startYear && p.Year <= endYear))
        {
            Console.WriteLine(paper.CoAuthors.Count.ToString());
            authorData.Add(paper.PaperID,
                            new AuthorData()
                            {
                                CoAuthors = paper.CoAuthors,
                                PaperCategory = paper.PaperCategory,
                                VenueID = paper.VenueID,
                                Year = paper.Year
                            });
            Console.WriteLine("After");
            Console.WriteLine(authorData.Last().Value.Count.ToString());
        }
        return authorData;
    }
    class AuthorData
    {
           public List<int> CoAuthors { set; get; }
           public int PaperCategory { set; get; }
           public int VenueID { set; get; }
           public int Year { set; get; }
    }
