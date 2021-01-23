    class TimePickerFragment : MvxDialogFragment
    {
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            EnsureBindingContextSet(savedInstanceState);
            return new TimePickerDialog(Activity, (sender, args) =>
            {
                //args contains new time
            }, DateTime.Now.Hour, DateTime.Now.Minute, true);
        }
    }
