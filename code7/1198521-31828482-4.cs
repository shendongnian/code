    class Ascii85
    {
    
        private const int _asciiOffset = 33;
        private const int decodedBlockLength = 4;
    
        private byte[] _encodedBlock = new byte[5];
        private uint _tuple;
    
        /// <summary>
        /// Encodes binary data into a plaintext ASCII85 format string
        /// </summary>
        /// <param name="ba">binary data to encode</param>
        /// <returns>ASCII85 encoded string</returns>
        public string Encode(byte[] ba)
        {
            StringBuilder sb = new StringBuilder((int)(ba.Length * (_encodedBlock.Length / decodedBlockLength)));
                 
            int count = 0;
            _tuple = 0;
            foreach (byte b in ba)
            {
                if (count >= decodedBlockLength - 1)
                {
                    _tuple |= b;
                    if (_tuple == 0)
                    {
                        sb.Append('z');
                    }
                    else
                    {
                        EncodeBlock(_encodedBlock.Length, sb);
                    }
                    _tuple = 0;
                    count = 0;
                }
                else
                {
                    _tuple |= (uint)(b << (24 - (count * 8)));
                    count++;
                }
            }
    
            // if we have some bytes left over at the end..
            if (count > 0)
            {
                EncodeBlock(count + 1, sb);
            }
    
            return sb.ToString();
        }
    
        private void EncodeBlock(int count, StringBuilder sb)
        {
            for (int i = _encodedBlock.Length - 1; i >= 0; i--)
            {
                _encodedBlock[i] = (byte)((_tuple % 85) + _asciiOffset);
                _tuple /= 85;
            }
    
            for (int i = 0; i < count; i++)
            {
                sb.Append((char)_encodedBlock[i]);
            }
    
        }
    }
