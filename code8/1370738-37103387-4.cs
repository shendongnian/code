	public class AttendenceViewAdapter : BaseAdapter<Attendence>
	{
		private List<Attendence> mstudents;
		private Context mcontext;
		
		public AttendenceViewAdapter(Context context, List<Attendence> stud)
		{
			mstudents = stud;
			mcontext = context;
		}
		// ...
		public override View GetView (int position, View convertView,   ViewGroup parent)
		{
			View view = convertView;
			Spinner spinner;
			if (view == null){
				view = LayoutInflater.From(mcontext).Inflate(Resource.Layout.listview_attendence , null, false);
				spinner = view.FindViewById<Spinner> (Resource.Id.spinnerTeacherAttendence);
				var adapter = ArrayAdapter.CreateFromResource (mcontext, Resource.Array.attendence_array, Android.Resource.Layout.SimpleDropDownItem1Line);
				adapter.SetDropDownViewResource (Android.Resource.Layout.SimpleSpinnerDropDownItem);
				spinner.Focusable = false;
				spinner.FocusableInTouchMode = false;
				spinner.Clickable = true;
				spinner.ItemSelected += Spinner_ItemSelected;
				spinner.Adapter = adapter;
			}
			else {
				spinner = view.FindViewById<Spinner> (Resource.Id.spinnerTeacherAttendence);
			}
				
			// set view properties to reflect data for the given row
			TextView txtStudent = view.FindViewById<TextView>(Resource.Id.textStudentNameTeacherAttendence);
			txtStudent.Text = mstudents[position].StudentName;
			
			// TODO: use mstudents[position].Attendence here
			var abcde = spinner.SelectedItemPosition;
			spinner.SetSelection(abcde);
			spinner.Tag = position; // use this to know which student has been edited
			
			// return the view, populated with data, for display
			return view;
		}
		void Spinner_ItemSelected (object sender, AdapterView.ItemSelectedEventArgs e)
		{
			Spinner spinner = (Spinner)sender;
			var abc = spinner.SelectedItemPosition;
            var position = (int)spinner.Tag;
			spinner.RequestFocusFromTouch ();
			spinner.SetSelection (abc);
			
			mstudents[position].Attendence = //TODO: selected value of the spinner;
		}
	}
