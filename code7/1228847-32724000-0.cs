    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace MyNamespace
    {
        public class ThrottledStream : Stream
        {
            Stream _InputStream = null;
            int _Throttle = 0;
            Stopwatch _watch = Stopwatch.StartNew();
            long _TotalBytesRead = 0;
            public ThrottledStream(Stream @in, int throttleKb)
            {
                _Throttle = (throttleKb / 8) * 1024;
                _InputStream = @in;
            }
            public override bool CanRead
            {
                get { return _InputStream.CanRead; }
            }
            public override bool CanSeek
            {
                get { return _InputStream.CanSeek; }
            }
            public override bool CanWrite
            {
                get { return false; }
            }
            public override void Flush()
            {
            }
            public override long Length
            {
                get { return _InputStream.Length; }
            }
            public override long Position
            {
                get
                {
                    return _InputStream.Position;
                }
                set
                {
                    _InputStream.Position = value;
                }
            }
            public override int Read(byte[] buffer, int offset, int count)
            {
                var newcount = GetBytesToReturn(count);
                int read = _InputStream.Read(buffer, offset, newcount);
                Interlocked.Add(ref _TotalBytesRead, read);
                return read;
            }
            public override long Seek(long offset, SeekOrigin origin)
            {
                return _InputStream.Seek(offset, origin);
            }
            public override void SetLength(long value)
            {
            }
            public override void Write(byte[] buffer, int offset, int count)
            {
            }
            int GetBytesToReturn(int count)
            {
                return GetBytesToReturnAsync(count).Result;
            }
            async Task<int> GetBytesToReturnAsync(int count)
            {
                if (_Throttle <= 0)
                    return count;
                long canSend = (long)(_watch.ElapsedMilliseconds * (_Throttle / 1000.0));
                int diff = (int)(canSend - _TotalBytesRead);
                if (diff <= 0)
                {
                    var waitInSec = ((diff * -1.0) / (_Throttle));
                    await Task.Delay((int)(waitInSec * 1000)).ConfigureAwait(false);
                }
                if (diff >= count) return count;
                return diff > 0 ? diff : Math.Min(1024 * 8, count);
            }
        }
    }
