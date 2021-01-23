    public class MyListener : TextWriterTraceListener {
    
          public MyListener(Stream s) : base(s) {
          }
    
          public MyListener(string s, string s1) : base(s, s1) {
          }
    
          public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message) {
            if (this.Filter != null && !base.Filter.ShouldTrace(eventCache, source, eventType, id, message, null, null, null))
              return;
            this.WriteLine(message);
            this.WriteFooter(eventCache);
          }
    
          private bool IsEnabled(TraceOptions opts) {
            return (uint)(opts & this.TraceOutputOptions) > 0U;
          }
    
          private void WriteFooter(TraceEventCache eventCache) {
            if (eventCache == null)
              return;
            this.IndentLevel = this.IndentLevel + 1;
            if (this.IsEnabled(TraceOptions.ProcessId))
              this.WriteLine("ProcessId=" + (object)eventCache.ProcessId);
            if (this.IsEnabled(TraceOptions.LogicalOperationStack)) {
              this.Write("LogicalOperationStack=");
              Stack logicalOperationStack = eventCache.LogicalOperationStack;
              bool flag = true;
              foreach (object obj in logicalOperationStack) {
                if (!flag)
                  this.Write(", ");
                else
                  flag = false;
                this.Write(obj.ToString());
              }
              this.WriteLine(string.Empty);
            }
            if (this.IsEnabled(TraceOptions.ThreadId))
              this.WriteLine("ThreadId=" + eventCache.ThreadId);
            if (this.IsEnabled(TraceOptions.DateTime))
              this.WriteLine("DateTime=" + eventCache.DateTime.ToString("o", (IFormatProvider)CultureInfo.InvariantCulture));
            if (this.IsEnabled(TraceOptions.Timestamp))
              this.WriteLine("Timestamp=" + (object)eventCache.Timestamp);
            if (this.IsEnabled(TraceOptions.Callstack))
              this.WriteLine("Callstack=" + eventCache.Callstack);
            this.IndentLevel = this.IndentLevel - 1;
          }
        }
