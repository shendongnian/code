        [ExcelFunction]
        public static object AsyncRCallTest(int a1, int a2)
        {
            return ExcelAsyncUtil.Run("AsyncRCallTest", new object[] { a1, a2 }, delegate
            {
                return SyncRCallTest(a1, a2);
            });
        }
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static object SyncRCallTest(int a1, int a2)
        {
            try
            {
                var a = RConnection.Evaluate(a1);
                var b = RConnection.Evaluate(a2);
                return a + b;
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
