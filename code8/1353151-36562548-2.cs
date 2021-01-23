	public static void Main()
	{
		Console.WriteLine("Hello World");
		var uri = "Http://www.SomeDomain.com";
		var linksValidator = new LinksValidator();
		linksValidator.ShouldNotHaveValidationErrorFor(uri);
	}
	public class LinksValidator : AbstractValidator<LinksValidator.UrlWrapper>
	{
		public class UrlWrapper { public string Url { get; set; } }
		public LinksValidator()
		{
			RuleFor(x => x.Url)
				.Must(LinkMustBeAUri)
				.WithMessage("Link '{PropertyValue}' must be a valid URI. eg: http://www.SomeWebSite.com.au");
		}
		
        //Optional 'overload' since l => l.Url seems to be superfluous
		public void ShouldNotHaveValidationErrorFor(string uri)
		{
			this.ShouldNotHaveValidationErrorFor(l => l.Url, uri);
		}
		private static bool LinkMustBeAUri(string link)
		{
			if (string.IsNullOrWhiteSpace(link))
			{
				return false;
			}
            //Courtesy of @Pure.Krome's comment and https://stackoverflow.com/a/25654227/563532
			Uri outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps)
		}
	}
