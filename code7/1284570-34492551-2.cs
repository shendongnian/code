    using System;
    using Microsoft.ApplicationInsights.Channel;
    using Microsoft.ApplicationInsights.Extensibility;
    using Microsoft.ApplicationInsights.Extensibility.Implementation;
    namespace Streambolics.Telemetry
    {
      public class ReliableTelemetryChannel : ITelemetryChannel
      {
        private Uri _EndpointAddress;
        private int _Attempts, _Successes, _Failures;
        private Exception _LastFailure;
        private DateTime _LastFailureTime;
        public ReliableTelemetryChannel ()
        {
          EndpointAddress = TelemetryConfiguration.Active?.TelemetryChannel?.EndpointAddress;
        }
        public bool? DeveloperMode {
            get { return true; }
            set { }
        }
        public string EndpointAddress {
            get { return _EndpointAddress?.ToString (); }
            set {
                if (String.IsNullOrEmpty (value))
                    _EndpointAddress = null;
                else
                    _EndpointAddress = new Uri (value);
            }
        }
        public void Flush () { }
        public void Send (ITelemetry item)
        {
          _Attempts++;
          try
          {
            item.Timestamp = DateTime.Now;
            byte[] data = JsonSerializer.Serialize (new ITelemetry[] { item });
            var transmission = new Transmission (_EndpointAddress, data, "application/x-json-stream", JsonSerializer.CompressionType);
            transmission.SendAsync ().GetAwaiter ().GetResult ();
            _Successes++;
          }
          catch (Exception ex)
          {
              _Failures++;
              _LastFailure = ex;
              _LastFailureTime = DateTime.Now;
          }
        }
        protected virtual void Dispose (bool disposing) { }
        public void Dispose ()
        { Dispose (true); }
      }
    }
