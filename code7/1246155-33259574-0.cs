            catch (CUDAInterop.CUDAException x)
            {
                var code = x.Data0;
                Console.WriteLine("ErrorCode = {0}", code);
                Assert.Fail();
            }
