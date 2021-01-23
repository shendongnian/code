    using System.ServiceProcess;
	using Hangfire;
	using Hangfire.SqlServer;
	namespace WindowsService1
	{
		public partial class Service1 : ServiceBase
		{
			private BackgroundJobServer _server;
			public Service1()
			{
				InitializeComponent();
				GlobalConfiguration.Configuration.UseSqlServerStorage("connection_string");
			}
			protected override void OnStart(string[] args)
			{
				_server = new BackgroundJobServer();
				
				// It will run everyday at 9:00
				RecurringJob.AddOrUpdate<EmailService>( emailService => emailService.SendEmail() , "0 9 * * *");
			}
			protected override void OnStop()
			{
				_server.Dispose();
			}
		}
	}
	public class EmailService
	{
		public void SendEmail()
		{
			// code for sending email here
		}
	}
