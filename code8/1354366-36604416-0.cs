    public class TimePickerFragment : DialogFragment, TimePickerDialog.IOnTimeSetListener
    {
        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            Calendar c = Calendar.Instance;
            int hour = c.Get(CalendarField.HourOfDay);
            int minute = c.Get(CalendarField.Minute);
            return new TimePickerDialog(Activity, this, hour, minute, DateFormat.Is24HourFormat(Activity));
        }
        public void OnTimeSet(TimePicker view, int hourOfDay, int minute)
        {
            //Do something when time chosen by user
        }
    }
