        public class MyOperationsClass
        {
            public void ReallyGreatOperation(object obj, object z)
            {
                IList list = obj as IList;
                if (list.Contains(z))
                    ((dynamic)z).AddDataPartsToEachOther();
            }
        }
