    public class Reminder
    {
        public string _Content { get; set; }
        public DateTime _Date { get; set; }
        public DateTime _Time { get; set; }
        public DateTime _Date { get; set; }
    }
    Reminder objReminder = new Reminder();
    objReminder._Content = TextField.Text;
    objReminder._Content = dpkDate.Value.Value;
    objReminder._Content = tpkDate.Value.Value.TimeOfDay;
    objReminder._Content = _Date.Date + _Time;
    IsolatedStorageSettings.ApplicationSettings["objReminder"] = objReminder;
