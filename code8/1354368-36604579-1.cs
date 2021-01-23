    class TimePickerFragment : DialogFragment
    {
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            return new TimePickerDialog(Activity, (sender, args) =>
            {
                //args contains new time
            }, DateTime.Now.Hour, DateTime.Now.Minute, true);
        }
    }
