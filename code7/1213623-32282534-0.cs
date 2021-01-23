	public class Vehicle {}
	public class Coverage {}
	// Set these as "internal" as you were hoping for...
	internal class VehicleList : IEnumerable<Vehicle>
	{
		public void Foo() {}
	}
	internal class CoverageList : IEnumerable<Coverage>
	{
		public void Bar() {}
	}
	public abstract class Quote
	{
		// Mark these as "private"
		private VehicleList vehicles;
		private CoverageList coverages;
		internal Quote() {}
		public IReadOnlyCollection<Vehicle> Vehicles
		{
			get { return this.vehicles.AsReadOnly(); }
		}
		public IReadOnlyCollection<Coverage> Coverages
		{
			get { return this.coverages.AsReadOnly(); }
		}
		// Add protected methods to manipulate the private fields.
		protected void PerformFooOnVehicles()
		{
			this.vehicles.Foo();
		}
		protected void PerformBarOnCoverages()
		{
			this.coverages.Bar();
		}
		
	}
	public sealed class OhQuote : Quote
	{
		// We now have indirect access to Quote's private fields.
		public void Baz()
		{
			this.PerformBarOnCoverages();
			this.PerformFooOnVehicles();
		}
	}
	public sealed class InQuote : Quote {}
	public sealed class MiQuote : Quote {}
