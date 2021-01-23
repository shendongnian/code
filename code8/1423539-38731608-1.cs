        static void Main(string[] args) {
            var arr = new DateTimeOffset[] {
                new DateTimeOffset(0x123456789abcdef0, TimeSpan.FromMinutes(60)),
                new DateTimeOffset(0x123456789abcdef0, TimeSpan.FromMinutes(60)),
            };
            System.Diagnostics.Debugger.Break();
        }
