    public interface IDataRequest
    {
        bool TrySetException(Exception ex);
    }
    public abstract class DataRequest<T> : IDataRequest
    {
        public TaskCompletionSource<T> RequestTask { get; } = new TaskCompletionSource<T>();
        public bool TrySetException(Exception ex)
        {
            return RequestTask.TrySetException(ex);
        }
    }
    public class TempRequest : DataRequest<double>
    {
    }
    public class RpmRequest : DataRequest<int>
    {
    }
    public sealed class DeviceManager : IDisposable
    {
        private readonly Task _workerThread;
        private readonly BlockingCollection<IDataRequest> _queue;
        private readonly SerialPort _serialPort;
        public DeviceManager()
        {
            _queue = new BlockingCollection<IDataRequest>();
            _workerThread = Task.Factory.StartNew(ProcessQueue, CancellationToken.None, TaskCreationOptions.LongRunning, TaskScheduler.Default);
            _serialPort = //...
        }
        
        public event EventHandler<double> TempUpdate;
        public event EventHandler<int> RpmUpdate;
        public Task<double> RequestTemp()
        {
            var request = new TempRequest();
            _queue.Add(request);
            return request.RequestTask.Task;
        }
        public Task<int> RequestRpm()
        {
            var request = new RpmRequest();
            _queue.Add(request);
            return request.RequestTask.Task;
        }
        public void Dispose()
        {
            _queue.CompleteAdding();
            _workerThread.Wait();
        }
        private void ProcessQueue()
        {
            foreach (var dataRequest in _queue.GetConsumingEnumerable())
            {
                try
                {
                    if (dataRequest is TempRequest)
                    {
                        DoTempRequest((TempRequest)dataRequest);
                    }
                    else if (dataRequest is RpmRequest)
                    {
                        DoRpmRequest((RpmRequest)dataRequest);
                    }
                    else
                    {
                        throw new NotSupportedException($"A Request of type {dataRequest.GetType()} is not supported.");
                    }
                }
                catch (Exception ex)
                {
                    dataRequest.TrySetException(ex);
                }
            }
        }
        private void DoTempRequest(TempRequest dataRequest)
        {
            _serialPort.WriteLine("Temp ?");
            var line = _serialPort.ReadLine();
            double result;
            //I am deliberately using Parse instead of TryParse so responses that 
            //fail to parse will throw and get their exception propagated up via the 
            //catch in ProcessQueue().
            result = double.Parse(line);
            
            //Sends the info back to the caller saying it is done and what the result was.
            dataRequest.RequestTask.TrySetResult(result);
            //Raises the event so subscribers know the new value.
            OnTempUpdate(result);
        }
        private void DoRpmRequest(RpmRequest dataRequest)
        {
            _serialPort.WriteLine("RPM ?");
            var line = _serialPort.ReadLine();
            int result;
            result = int.Parse(line);
            
            dataRequest.RequestTask.TrySetResult(result);
            OnRpmUpdate(result);
            
        }
        private void OnTempUpdate(double result)
        {
            TempUpdate?.Invoke(this, result);
        }
        private void OnRpmUpdate(int result)
        {
            RpmUpdate?.Invoke(this, result);
        }
    }
