        public void SO30435185_InvalidTypeOwner()
        {
            try {
                // not shown for brevity: something very similar to your code
                Assert.Fail();
            } catch(InvalidOperationException ex)
            {
                ex.Message.IsEqualTo("An enumerable sequence of parameters (arrays, lists, etc) is not allowed in this context");
            }
        }
