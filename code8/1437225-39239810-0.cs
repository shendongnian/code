    public class TrafficLightViewModel : ViewModelBase
    {        
        private bool green;
        private bool red;
        private bool yellow;
        private CancellationTokenSource greenCts;
        private CancellationTokenSource redCts;
        private CancellationTokenSource yellowCts;
        private UaTcpSessionClient session;
        public TrafficLightViewModel(UaTcpSessionClient session)
        {
            this.session = session;
        }
        public bool Green
        {
            get { return this.green; }
            set
            {
                this.green = value;
                this.greenCts?.Cancel();
                this.greenCts = new CancellationTokenSource();
                var request = new WriteRequest
                {
                    NodesToWrite = new[]
                    {
                        new WriteValue
                        {
                            NodeId = NodeId.Parse("ns=2;s=GreenLight"),
                            AttributeId = AttributeIds.Value,
                            Value = new DataValue(value)
                        }
                    }
                };
                this.WriteOutputAsync(request, this.greenCts.Token);
            }
        }
        // add yellow and red
        private async void WriteOutputAsync(WriteRequest request, CancellationToken token)
        {
            try
            {
                while (!await this.TryWriteAsync(request))
                {
                    await Task.Delay(5000, token);
                }
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine($"Canceled writing output : {request.NodesToWrite[0].NodeId}");
            }
        }
        private async Task<bool> TryWriteAsync(WriteRequest request)
        {
            try
            {
                var response = await this.Session.WriteAsync(request);
                for (int i = 0; i < response.Results.Length; i++)
                {
                    if (StatusCode.IsBad(response.Results[i]))
                    {
                        Debug.WriteLine($"Error writing output '{request.NodesToWrite[i].NodeId}' {request.NodesToWrite[i].Value.GetValue()}: {StatusCodes.GetDefaultMessage(response.Results[i])}");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error writing outputs : {ex.Message}");
                return false;
            }
        }
    }
