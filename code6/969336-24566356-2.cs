    public class Timer {
        
        public List<DateTime> SpawnTimes { get; private set; }
        ...
        
        public Timer() {
            this.SpawnTimes = new List<DateTime>();
        }
        
        public Timer(String boss, /*String runtime,*/ BossPriority priority, params String[] spawnTimes) : this() {
            
            this.Boss = boss;
    //      this.Runtime = TimeSpan.Parse( runtime );
            this.Priority = priority;
            
            foreach(String time in spawnTimes) {
                
                this.SpawnTimes.Add( DateTime.ParseExact( time, "HH:mm" ) );
            }
            
        }
    }
