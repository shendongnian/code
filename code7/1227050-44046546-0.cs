        /// <summary>
        ///     Gets the manufacturer identification assigned by Microsoft to the device vendors in string
        /// </summary>
        public string ManufacturerCode
        {
            get
            {
                var edidCode = ManufacturerId;
                edidCode = ((edidCode & 0xff00) >> 8) | ((edidCode & 0x00ff) << 8);
                var byte1 = (byte) 'A' + ((edidCode >> 0) & 0x1f) - 1;
                var byte2 = (byte) 'A' + ((edidCode >> 5) & 0x1f) - 1;
                var byte3 = (byte) 'A' + ((edidCode >> 10) & 0x1f) - 1;
                return $"{Convert.ToChar(byte3)}{Convert.ToChar(byte2)}{Convert.ToChar(byte1)}";
            }
        }
