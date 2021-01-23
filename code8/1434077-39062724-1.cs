    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        ...
        [HttpGet("GetHeroes")] // Here comes method name
        public IEnumerable<Character> GetHeroes()
        {
            return _characterRepository.ListAll().OrderBy(x => x.Name);
        }
    }
