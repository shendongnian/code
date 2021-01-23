    class Album : List<Track>
    {
        public Album() : base() { }
        public Album(IEnumerable<Track> tracks) : base(tracks) { }
        /// <summary>
        /// Sort in place the album of tracks alphabetically by name 
        /// </summary>
        public void SortByAlphabet()
        {
            Sort((t1, t2) => t1.Name.CompareTo(t2.Name));
        }
        /// <summary>
        /// Return a new Album with tracks sorted alphabetically by name.
        /// </summary>
        /// <returns></returns>
        public Album OrderByAlphabet()
        {
            return new Album(this.OrderBy(t => t.Name));
        }
    }
