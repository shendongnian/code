	public interface IAthleteService {
		Task<List<Athlete>> GetAthletesByCountryAsync(string country, CancellationToken token);
	}
	public class AthleteService : IAthleteService {
		private MyDbContext _context;
		public async Task<List<Athlete>> GetAthletesByCountryAsync(string country, CancellationToken token)
		{
			return await _context.Athletes.Where(athlete => athlete.Country == country).ToListAsync(token).ConfigureAwait(false);
		}
	}
	public class MyController : Controller
	{
		private readonly IAthleteService _service;
		//...
		public async Task<IActionResult> Index(CancellationToken token)
		{
		   MyViewModel myvm = new MyViewModel();
		   myvm.ItalianAthletes = await _service.GetAthletesByCountryAsync("Italy", token).ConfigureAwait(true);
		   // rest of code
		}	
	}
