    using System.Runtime.CompilerServices.Unsafe;
    [Test]
    public unsafe void CouldUseNewUnsafePackage() {
        var dt = new KeyValuePair<DateTime, decimal>[2];
        dt[0] = new KeyValuePair<DateTime, decimal>(DateTime.UtcNow.Date, 123.456M);
        dt[1] = new KeyValuePair<DateTime, decimal>(DateTime.UtcNow.Date.AddDays(1), 789.101M);
        var obj = (object)dt;
        byte[] asBytes = Unsafe.As<byte[]>(obj);
        //Console.WriteLine(asBytes.Length); // prints 2
        fixed (byte* ptr = &asBytes[0]) {
            // reading this: https://github.com/dotnet/coreclr/issues/5870
            // it looks like we could fix byte[] and actually KeyValuePair<DateTime, decimal> will be fixed
            // because:
            // "GC does not care about the exact types, e.g. if type of local object 
            // reference variable is not compatible with what is actually stored in it, 
            // the GC will still track it fine."
            for (int i = 0; i < (8 + 16) * 2; i++) {
                Console.WriteLine(*(ptr + i));
            }
            var firstDate = *(DateTime*)ptr;
            Assert.AreEqual(DateTime.UtcNow.Date, firstDate);
            Console.WriteLine(firstDate);
            var firstDecimal = *(decimal*)(ptr + 8);
            Assert.AreEqual(123.456M, firstDecimal);
            Console.WriteLine(firstDecimal);
            var secondDate = *(DateTime*)(ptr + 8 + 16);
            Assert.AreEqual(DateTime.UtcNow.Date.AddDays(1), secondDate);
            Console.WriteLine(secondDate);
            var secondDecimal = *(decimal*)(ptr + 8 + 16 + 8);
            Assert.AreEqual(789.101M, secondDecimal);
            Console.WriteLine(secondDecimal);
        }
    }
