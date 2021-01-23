    public class NormComparableFilm
    {
        [Key]
        public int Id { get; set; }
        public int  FilmId { get; set; }
        public intComparableFilmId { get; set; }
    
        [ForeignKey("FilmId")]
        [InverseProperty("NormComparableFilms")]
        public virtual Film Film { get; set; }
        [ForeignKey("ComparableFilmId")]
        public virtual Film ComparableFilm { get; set; }
    
    }
