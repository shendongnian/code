    public sealed class DisplayAttributeLocalisationProvider : IDisplayMetadataProvider {
		private IHtmlLocalizer localiser;
		public DisplayAttributeLocalisationProvider(IHtmlLocalizer localiser) {
			this.localiser = localiser;
		}
		public void GetDisplayMetadata(DisplayMetadataProviderContext context)
			=> context
				.PropertyAttributes
				.Where(attribute => attribute is DisplayAttribute)
				.Cast<DisplayAttribute>()
				.ExecuteAction(x =>
					x.Name = this
						.localiser
						.Html(x?.Name)
						.Value);
