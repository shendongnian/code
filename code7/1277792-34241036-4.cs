        public void CallingMethod()
        {
            try
            {
                myMethod(23);
            }
            catch (MyException e)
            {
                Console.WriteLine(e.Message + e.ExtraData);
            }
        }
