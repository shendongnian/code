	public class ToolbarImageEditorExtender : Component
	{
		private static bool _alreadyInitialized;
		public ToolbarImageEditorExtender()
		{
            // no need to reinitialize if we drop more than one component
			if (_alreadyInitialized)
				return;
			_alreadyInitialized = true;
            // the ChangeTypeProperties function above. I just made a generic version
			ChangeTypeProperties<OtherControl>(nameof(OtherControl.Glyph), nameof(OtherControl.LargeGlyph));
			ChangeTypeProperties<AButton>(nameof(AButton.SmallImage), nameof(AButton.LargeImage));
            // etc.
		}
	}
