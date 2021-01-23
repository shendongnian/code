	private bool areArtistsEqual(ICollection<Artist> arts1, ICollection<Artist> arts2) {
		return arts1.Count == arts2.Count && //have the same amount of artists
			arts1.Select(x => x.ArtistId)
			.Except(arts2.Select(y => y.ArtistId))
			.ToList().Count == 0; //when excepted, returns 0
	}
