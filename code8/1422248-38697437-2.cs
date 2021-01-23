        public class CallScheduleProfileViewModel
        {
            public CallScheduleProfileViewModel()
            {
                // doesn't help as Automapper overwrites it
                this.Title = new Entry<bool>(true, "Title");                
                Task.Run(() =>
                {
                    Thread.Sleep(200);
                    // does help because AM has done all mapping already
                    this.Title = new Entry<bool>(true, "Title");                
                });
            }
            public Entry<bool> Title { get; set; }
        }
