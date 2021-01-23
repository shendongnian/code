    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan StartTime = TimeSpan.Parse("09:00:00");
            TimeSpan EndTime = TimeSpan.Parse("09:30:00");
    
            List<PhoneData> oPhoneData = GetPhoneData(@"z:\smdr(backup12-04-2016).csv");
            dgList.DataSource = oPhoneData;
    
            int incomingCount = (from row in oPhoneData
                                 where row.direction == "I"
                                 && row.Call_Start.TimeOfDay >= StartTime
                                 && row.Call_Start.TimeOfDay <= EndTime
                                 && row.Is_Internal == 0
                                 && row.continuation == 0
                                 && row.call_duration.TotalSeconds > 0
                                 && row.party1name != "Voice Mail"
                                 && !row.party1name.StartsWith("VM ")
                                 select 1).Count();
    
        }
    
        public List<PhoneData> GetPhoneData(string strFileName)
        {
            return File.ReadLines(strFileName)
                .Skip(1)
                .Where(s => s != "")
                .Select(s => s.Split(new[] { ',' }))
                .Select(a => new PhoneData
                {
                    Call_Start = DateTime.Parse( a[0]),
                    call_duration = TimeSpan.Parse(a[1]),
                    Ring_duration = int.Parse(a[2]),
                    direction = a[4],
                    Is_Internal =Convert.ToInt32( a[8]),
                    continuation = int.Parse( a[10]),
                    party1name = a[13]
                })
                .ToList();
        }
    }
    
    public class PhoneData
    {
        public DateTime Call_Start { get; set; }
        public TimeSpan call_duration { get; set; }
        public Int32 Ring_duration { get; set; }
        public string direction { get; set; }
        public Int32 Is_Internal { get; set; }
        public Int32 continuation { get; set; }
        public string party1name { get; set; }
        
    }
