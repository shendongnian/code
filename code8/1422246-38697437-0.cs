        public class CallScheduleProfileViewModel
        {
            public CallScheduleProfileViewModel()
            {
                Task.Run(() =>
                {
                    Thread.Sleep(200);
                    this.Title = new Entry<bool>(true, "Title");                
                });
            }
            public Entry<bool> Title { get; set; }
        }
