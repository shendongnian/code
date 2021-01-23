    using System;
    using System.IO;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.Crypto.Parameters;
    
    namespace StreamHelpers
    {
        public class StreamEncryptDecrypt : Stream
        {
            private readonly Stream _streamToWrap;
            private readonly IBlockCipher _cipher;
            private readonly ICipherParameters _key;
            private readonly byte[] _iv;
            private readonly byte[] _counter;
            private readonly byte[] _counterOut;
            private readonly byte[] _output;
            private long currentBlockCount;
    
            public StreamEncryptDecrypt(Stream streamToWrap, IBlockCipher cipher, ParametersWithIV keyAndIv)
            {
                _streamToWrap = streamToWrap;
                _cipher = cipher;
                _key = keyAndIv.Parameters;
                _cipher.Init(true, _key);
                _iv = keyAndIv.GetIV();
                _counter = new byte[_cipher.GetBlockSize()];
                _counterOut = new byte[_cipher.GetBlockSize()];
                _output =  new byte[_cipher.GetBlockSize()];
    
                if (_iv.Length != _cipher.GetBlockSize())
                {
                    throw new Exception("IV must be the same size as the cipher block size");
                } 
                InitCipher();
            }
    
            private void InitCipher()
            {
                long position = _streamToWrap.Position;
    
                Array.Copy(_iv, 0, _counter, 0, _counter.Length);
                currentBlockCount = 0;
                var targetBlock = position/_cipher.GetBlockSize();
                while (currentBlockCount < targetBlock)
                {
                    IncrementCounter(false);
                }
                _cipher.ProcessBlock(_counter, 0, _counterOut, 0);
            }
    
            private void IncrementCounter(bool updateCounterOut = true)
            {
                currentBlockCount++;
                // Increment the counter
                int j = _counter.Length;
                while (--j >= 0 && ++_counter[j] == 0)
                {
                }
                _cipher.ProcessBlock(_counter, 0, _counterOut, 0);
            }
    
    
    
            public override long Position
            {
                get { return _streamToWrap.Position; }
                set
                {
                    _streamToWrap.Position = value;
                    InitCipher();
                     
                    
                }
            }
    
            public override long Seek(long offset, SeekOrigin origin)
            {
                var result = _streamToWrap.Seek(offset, origin);
                InitCipher();
                return result;
            }
    
            public void ProcessBlock(
                byte[] input,
                int offset,
                int length, long streamPosition)
            {
                if (input.Length < offset+length)
                    throw new ArgumentException("input does not match offset and length");
                var blockSize = _cipher.GetBlockSize();
                var startingBlock = streamPosition / blockSize;
                var blockOffset = (int)(streamPosition - (startingBlock * blockSize));
    
                while (currentBlockCount < streamPosition / blockSize)
                    {
                        IncrementCounter();
                    }
    
                //process the left over from current block
                if (blockOffset !=0)
                {
                    var blockLength = blockSize - blockOffset;
                    blockLength = blockLength > length ? length : blockLength;
                    //
                    // XOR the counterOut with the plaintext producing the cipher text
                    //
                    for (int i = 0; i < blockLength; i++)
                    {
                        input[offset + i] = (byte)(_counterOut[blockOffset + i] ^ input[offset + i]);
                    }
    
                    offset += blockLength;
                    length -= blockLength;
                    blockOffset = 0;
    
                    if (length > 0)
                    {
                        IncrementCounter();
                    }
                }
    
                //need to loop though the rest of the data and increament counter when needed
                while (length > 0)
                {
                    var blockLength =  blockSize > length ? length : blockSize;
                    //
                    // XOR the counterOut with the plaintext producing the cipher text
                    //
                    for (int i = 0; i < blockLength; i++)
                    {
                        input[offset + i] = (byte)(_counterOut[i] ^ input[offset + i]);
                    }
                    offset += blockLength;
                    length -= blockLength;
                    if (length > 0)
                    {
                        IncrementCounter();
                    }
                }
            }
    
           
    
    
            public override int Read(byte[] buffer, int offset, int count)
            {
                var pos = _streamToWrap.Position;
                var result = _streamToWrap.Read(buffer, offset, count);
                ProcessBlock(buffer, offset, result, pos);
                return result;
            }
    
            public override void Write(byte[] buffer, int offset, int count)
            {
                var input = new byte[count];
                Array.Copy(buffer, offset, input, 0, count);
                ProcessBlock(input, 0, count, _streamToWrap.Position);
                _streamToWrap.Write(input, offset, count);
            }
    
           
    
            public override void Flush()
            {
                _streamToWrap.Flush();
            }
    
    
            public override void SetLength(long value)
            {
                _streamToWrap.SetLength(value);
            }
    
            public override bool CanRead
            {
                get { return _streamToWrap.CanRead; }
            }
    
            public override bool CanSeek
            {
                get { return true; }
                
            }
    
            public override bool CanWrite
            {
                get { return _streamToWrap.CanWrite; }
            }
    
            public override long Length
            {
                get { return _streamToWrap.Length; }
            }
    
            protected override void Dispose(bool disposing)
            {
                if (_streamToWrap != null)
                {
                    _streamToWrap.Dispose();
                }
    
                base.Dispose(disposing);
            }
        }
    }
