        public static void DisposeCOM(dynamic obj)
        {
            if (obj != null)
            {
                Marshal.ReleaseComObject(obj);
            }
        }
