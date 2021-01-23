    private int carry = 0;        
            public byte[] AddRecursive(byte[] a, byte[] b)
            {
                //Start from bottom of the byte[] array
                a = a.Reverse().ToArray();
                b = b.Reverse().ToArray();
                if (a.Length == 0) return new byte[] { };            
                int tempresult = a[0] + b[0] + carry;
                byte[] z = new byte[]
                { (byte)(tempresult) };
                carry = tempresult / (byte.MaxValue + 1);
                return z.Concat(AddRecursive(a.Skip(1).ToArray(), b.Skip(1).ToArray())).ToArray();
            }
    
    //Test//
    
     [Test]
            public void Add_UsingARecursiveAlgorithm_ValuesAreAdded()
            {
                //First Test
                byte[] expectedResult = addthisaddthat.AddRecursive(new byte[] { 1, 1, 1 }, new byte[] { 1, 1, 1 }).Reverse().ToArray();
                Assert.That(expectedResult, Is.EqualTo(new byte[] { 2, 2, 2 }));
                //Sec Test
                expectedResult = addthisaddthat.AddRecursive(new byte[] { 1, 1, 255 }, new byte[] { 0, 0, 1 }).Reverse().ToArray();
                Assert.That(expectedResult, Is.EqualTo(new byte[] { 1, 2, 0 }));
                //Third Test
                expectedResult = addthisaddthat.AddRecursive(new byte[] { 255, 255, 255 }, new byte[] { 255, 255, 255 }).Reverse().ToArray();
                Assert.That(expectedResult, Is.EqualTo(new byte[] { 255, 255, 254 }));
            }
