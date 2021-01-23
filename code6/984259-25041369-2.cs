    public class Reminder
    {
        public string _Content { get; set; }
        public DateTime _Date { get; set; }
        public DateTime _Time { get; set; }
        public DateTime _DateTime { get; set; }
    }
    Reminder objReminder = new Reminder();
    objReminder._Content = TextField.Text;
    objReminder._Date = dpkDate.Value.Value;
    objReminder._Time = tpkDate.Value.Value.TimeOfDay;
    objReminder._DateTime = _Date.Date + _Time;
    IsolatedStorageSettings.ApplicationSettings["objReminder"] = objReminder;
