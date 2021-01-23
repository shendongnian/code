        public class MyOperationsClass
        {
            public void ReallyGreatOperation(object obj, object z)
            {
                List<MyDataClass> x = obj as List<MyDataClass>;
                if (x.Contains(z))
                    ((dynamic)z).AddDataPartsToEachOther();
            }
        }
