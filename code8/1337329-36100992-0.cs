        [DllImport("Wrapper.dll", CallingConvention = CallingConvention.StdCall)]
        public unsafe static extern short Testmethod (SampleStructure** passstructurepointer);
 
         unsafe
                {
                    fixed(SampleStructure** p2p = new SampleStructure*[3])
                    {
                        for (short i = 0; i < 3; i++)
                        {
                            var a = stackalloc SampleStructure[1];
                            a->ps = i;
                            p2p[i] = a;
                        }
                        var s= Testmethod(p2p);
                    }
                }
