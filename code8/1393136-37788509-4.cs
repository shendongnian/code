        public List<int> GetCoAuthorsByYear(int _year)
        {
			var coAuthors = new List<int>();
			foreach(var paper in _Papers.Where(_paper => _paper._Year == _year))
			{
				coAuthors.AddRange(paper._CoAuthors);
			}
			return coAuthors;
        }
        public List<int> GetCoAuthorsBetweenYears(int _startYear, int _endYear)
        {
            var coAuthors = new List<int>();
			foreach(var paper in _Papers.Where(_paper => _paper._Year >= _startYear && _paper._Year <= _endYear))
			{
				coAuthors.AddRange(paper._CoAuthors);
			}
			return coAuthors;
        }
        public List<int> GetVenuesByYear(int _year)
        {
            var venues = new List<int>();
			foreach(var paper in _Papers.Where(_paper => _paper._Year == _year))
			{
				venues.AddRange(paper._VenueId);
			}
			return venues;
        }
        public List<int> GetVenuesBetweenYears(int _startYear, int _endYear)
        {
            var venues = new List<int>();
			foreach(var paper in _Papers.Where(_paper => _paper._Year >= _startYear && _paper._Year <= _endYear))
			{
				venues.Add(paper._VenueId);
			}
			return venues;
        }		
