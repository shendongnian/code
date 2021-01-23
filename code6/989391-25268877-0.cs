    using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security.Cryptography.X509Certificates;
	using System.Text;
	using Google.Apis.Auth.OAuth2;
	using Google.Apis.Drive.v2;
	using Google.Apis.Drive.v2.Data;
	using Google.Apis.Services;
	namespace UseWebServiceMethod
	{
		class Program
		{
			// Goto https://admin.google.com/AdminHome?chromeless=1#OGX:ManageOauthClients
			// Login met admin account => ****@***.***
			// Add/edit Client Name (Use Client ID of service account here) => 2***8.apps.googleusercontent.com
			// One or More API Scopes => https://www.googleapis.com/auth/drive 
			public const string ImpersonatedAccountEmail = "****@***.***";
			public const string ServiceAccountEmail      = "2******8@developer.gserviceaccount.com";
			public const string Key                      = @"C:\Users\Wouter\Desktop\GoogleTester\GoogleTester\A****c.p12";
			public const string FileToUpload             = @"C:\Users\Wouter\Desktop\GoogleTester\GoogleTester\whakingly.txt";
			public const string ApplicationName          = "A***l";
			static void Main()
			{
				var certificate = new X509Certificate2(Key, "notasecret", X509KeyStorageFlags.Exportable);
				var initializer = new ServiceAccountCredential.Initializer(ServiceAccountEmail)
				{
					Scopes = new[] { DriveService.Scope.Drive },
					User = ImpersonatedAccountEmail
				};
				var credential = new ServiceAccountCredential(initializer.FromCertificate(certificate));
				var driveService = new DriveService(new BaseClientService.Initializer()
				{
					HttpClientInitializer = credential,
					ApplicationName = ApplicationName
				});
				// Show all files
				var list = driveService.Files.List().Execute();
				if (list.Items != null)
					foreach (var fileItem in list.Items)
					{
						Console.WriteLine(fileItem.Title + " - " + fileItem.Description);
					}
				Console.WriteLine("Press Enter to continue.");
				Console.ReadLine();
				// Upload a new file
				File body = new File();
				body.Title = "whakingly.txt";
				body.Description = "A whakingly (that a new word I created just there) file thats uploaded with impersonation";
				body.MimeType = "text/plain";
				byte[] byteArray = System.IO.File.ReadAllBytes(FileToUpload);
				var stream = new System.IO.MemoryStream(byteArray);
				FilesResource.InsertMediaUpload request = driveService.Files.Insert(body, stream, "text/plain");
				request.Upload();
				File file = request.ResponseBody;
				Console.WriteLine("Press Enter to continue.");
				Console.ReadLine();
				// Show all files
				var list2 = driveService.Files.List().Execute();
				if (list2.Items != null)
					foreach (var fileItem in list2.Items)
					{
						Console.WriteLine(fileItem.Title + " - " + fileItem.Description);
					}
				Console.WriteLine("Press Enter to continue.");
				Console.ReadLine();
			}
		}
	}
