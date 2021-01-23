	public abstract class GuiItem { } // base class
	public class TextBlockVM : GuiItem { }
	public class CheckBoxVM : GuiItem { }
	public class TextBoxVM : GuiItem { }
	public class CustomViewModel : ViewModelBase
	{
		private GuiItem[] _GuiItems = new GuiItem[]
		{
			new TextBlockVM{},
			new CheckBoxVM{},
			new TextBoxVM{}
		};
		public GuiItem[] GuiItems { get { return this._GuiItems; } }
	}
