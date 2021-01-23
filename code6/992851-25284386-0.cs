    public class EditMvxListView : MvxListView
	{
		public EditStationsView Parent {
			get;
			set;
		}
		public EditMvxListView (Context context,IAttributeSet attrs) : base(context,attrs)
		{
		}
		protected override void ExecuteCommandOnItem (System.Windows.Input.ICommand command, int position)
		{
			var item = Adapter.GetRawItem (position) as Station;
			if (item.Name == "New Station") {
				Parent.ShowSearch ();
				return;
			}
			base.ExecuteCommandOnItem (command, position);
		}
	}
 
