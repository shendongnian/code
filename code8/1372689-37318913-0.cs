    class TestDataReader : DbDataReader
    {
        public override bool IsDBNull(int ordinal) {
            return false;
        }
        public override int FieldCount { get; } = 2;
        int rowCount = 1;
        public override bool HasRows { get; } = true;
        public override bool IsClosed { get; } = false;
        public override bool Read()
        {
            return (rowCount++) < 3;
        }
        public override object GetValue(int ordinal) {
            switch (ordinal) {
                // do not return anything for binary column here - it will not be called
                case 0:
                    return rowCount;
                default:
                    throw new Exception();
            }
        }
        public override Stream GetStream(int ordinal) {
            // instead - return your stream here
            if (ordinal == 1)
                return new MemoryStream(new byte[] {0x01, 0x23, 0x45, 0x67, 0x89});
            throw new Exception();
        }
        // bunch of irrelevant stuff
    }
