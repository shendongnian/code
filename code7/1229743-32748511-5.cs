    public class ObjectAndChangeChecker
    {
        public WeakReference ObjectReference { get; set; }
        public ChangeChecker ChangeChecker { get; set; }
    }
    public class ClassA
    {
        private static List<ObjectAndChangeChecker> m_ObjectAndChangeCheckers = new List<ObjectAndChangeChecker>();
        private static ChangeChecker GetOrAddChangeChecker(object calling_object)
        {
            //Get rid of ObjectAndChangeChecker objects than contain garbage collected objects
            m_ObjectAndChangeCheckers = m_ObjectAndChangeCheckers.Where(x => x.ObjectReference.IsAlive).ToList();
            var object_and_change_checker =
                m_ObjectAndChangeCheckers.FirstOrDefault(
                    x => object.ReferenceEquals(calling_object, x.ObjectReference.Target));
            if (object_and_change_checker == null)
            {
                object_and_change_checker = new ObjectAndChangeChecker()
                {
                    ChangeChecker = new ChangeChecker(),
                    ObjectReference = new WeakReference(calling_object)
                };
		        m_ObjectAndChangeCheckers.Add(object_and_change_checker);
            }
            return object_and_change_checker.ChangeChecker;
        }
        public static void MethodA(Rect area, object calling_object)
        {
            var value = GetOrAddChangeChecker(calling_object);
            if (value.Changed(area))
            {
                Debug.Log("ChangeMade");
            }
        }
    }
