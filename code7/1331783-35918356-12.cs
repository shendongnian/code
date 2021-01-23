    [RoutePrefix("api/artists")]
    public class ArtistsController : ApiController
    {
        Artist[] artists = new Artist[]
        {
            new Artist { Name = "Metallica",Id ="65f4f0c5-ef9e-490c-aee3-909e7ae6b2ab",Country ="US",Aliases ="Metalica" },
            new Artist { Name = "Lady Gaga",Id ="650e7db6-b795-4eb5-a702-5ea2fc46c848",Country ="US",Aliases ="Lady Ga Ga,Stefani Joanne Angelina Germanotta" },
            new Artist { Name = "Mumford & Sons",Id ="c44e9c22-ef82-4a77-9bcd-af6c958446d6",Country ="GB",Aliases ="" },
            new Artist { Name = "Mott the Hoople",Id ="435f1441-0f43-479d-92db-a506449a686b",Country ="GB",Aliases ="Mott The Hoppie,Mott The Hopple" },
            new Artist { Name = "Megadeth",Id ="a9044915-8be3-4c7e-b11f-9e2d2ea0a91e",Country ="US",Aliases ="Megadeath" },
            new Artist { Name = "John Coltrane",Id ="b625448e-bf4a-41c3-a421-72ad46cdb831",Country ="US",Aliases ="John Coltraine,John William Coltrane" }
        }
        };
        // GET api/artists
        [HttpGet]
        [Route("")]
        public IEnumerable<Artist> GetAllArtists()
        {
            return artists;
        }
    
        // GET api/artists/John
        [HttpGet]
        [Route("{name}")]
        public IHttpActionResult GetArtist(string name)
        {        
            IEnumerable<Artist> ArtistQuery = from Artist in artists
                                              where Artist.Name.Contains(name)
                                              select Artist;
            if (ArtistQuery == null)
            {
                return NotFound();
            }
            return Ok(ArtistQuery);
        }
    }
