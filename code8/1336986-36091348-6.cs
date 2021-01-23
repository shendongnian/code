    public class HighlightsObjectHandler {
		// Constants
		private final String
				  JsonKeysHighlightsHolder = "Items",
				  JsonKeysHighlightUrl = "Url",
				  JsonKeysHighlightTranslationsHolder = "Traducoes",
				  JsonKeysHighlightTranslationLanguage = "Idioma",
				  JsonKeysHighlightTranslationText = "Titulo",
				  JsonKeysHighlightTranslationImage = "Imagem";
	
		// Enumerators
	
		// Handlers
		private List<HighlightsListener>
				  _highlightsListeners = new ArrayList<HighlightsListener>();
	
		// Variables
		private String
				  _json;
		private Boolean
				  _updating;
		private List<HighlightObject>
				  _highlights;
	
		// Properties
		public String HighlightsJson() {
			return _json;
		}
		public void HighlightsJson(String highlightsJson) {
			// Validate the json. This cannot be null nor equal to the present one ( to prevent firing events on the same data )
			if (!highlightsJson.equals(_json) && highlightsJson != null) {
				_json = highlightsJson;
	
				OnHighlightsJsonChanged();
	
				ParseJson();
			}
		}
	
		public Boolean HighlightsUpdating() {
			return _updating;
		}
		private void HighlightsUpdating(Boolean isUpdating) {
			_updating = isUpdating;
		}
	
		public List<HighlightObject> Highlights() {
			return _highlights;
		}
	
		// Methods
		private void ParseJson() {
            if (HighlightsUpdating()) {
                return;
            }
			try {
				OnHighlightsContentsChanging();
	
				// Parse the JSON object
	
				OnHighlightsContentsChanged();
			} catch (JSONException exception) {
	
			}
		}
	
		// Events
		private void OnHighlightsJsonChanged() {
			for(HighlightsListener highlightsListener : _highlightsListeners) {
				highlightsListener.HighlightsJsonChanged();
			}
		}
	
		private void OnHighlightsContentsChanging() {
			HighlightsUpdating(true);
	
			for(HighlightsListener highlightsListener : _highlightsListeners) {
				highlightsListener.HighlightsContentChanging();
			}
		}
		private void OnHighlightsContentsChanged() {
			HighlightsUpdating(false);
	
			for(HighlightsListener highlightsListener : _highlightsListeners) {
				highlightsListener.HighlightsContentChanged();
			}
		}
	
		// Constructors
		public HighlightsObjectHandler() {
			_highlights = new List<HighlightObject>();
		}
	}
