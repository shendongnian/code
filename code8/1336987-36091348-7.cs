	public class HighlightsObjectHandler {
		// Constants
		private const String
			JsonKeysHighlightsHolder = "Items",
			JsonKeysHighlightUrl = "Url",
			JsonKeysHighlightTranslationsHolder = "Traducoes",
			JsonKeysHighlightTranslationLanguage = "Idioma",
			JsonKeysHighlightTranslationText = "Titulo",
			JsonKeysHighlightTranslationImage = "Imagem";
		// Enumerators
		// Handlers
		public event EventHandler HighlightsJsonChanged;
		public event EventHandler HighlightsContentChanging;
		public event EventHandler HighlightsContentChanged;
		// Variables
		private String
			_json;
		// Properties
		public String HighlightsJson {
			get {
				return _json;
			}
			set {
				if (value != _json && value != null) {
					_json = value;
					if (HighlightsJsonChanged != null) {
						HighlightsJsonChanged( this, eventArgs );
					}
					ParseJson();
				}
			}
		}
		public Boolean HighlightsUpdating { get; private set; }
		public List<HighlightObject> Highlights { get; private set; }
		// Methods
		private void ParseJson() {
			JsonObject
				jsonObject;
			if (JsonObject.TryParse( HighlightsJson, out jsonObject )) {
				HighlightsUpdating = true;
				if (HighlightsContentChanging != null) {
					HighlightsContentChanging( this, eventArgs );
				}
				
				// Json parsing
				HighlightsUpdating = false;
				if (HighlightsContentChanged != null) {
					HighlightsContentChanged( this, eventArgs );
				}
			}
		}
		// Events
		// Constructors
		public HighlightsObjectHandler() {
			Highlights = new List<HighlightObject>();
		}
	}
