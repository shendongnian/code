        public void SetValueAsString(int row, int field, string value)
        {
            string utf8Value = EncodingConverter.Utf16ToUtf8(value);
            GDALRATSetValueAsString(GDALRasterAttributeTableH, row, field, utf8Value);
        }
        public string GetValueAsString(int row, int field)
        {
            string value = null;
            var pointer = GDALRATGetValueAsString(GDALRasterAttributeTableH, row, field);
            if (pointer != IntPtr.Zero)
            {
                string utf8Value = Marshal.PtrToStringAnsi(pointer);
                value = EncodingConverter.Utf8ToUtf16(utf8Value);
            }
            return value;
        }
