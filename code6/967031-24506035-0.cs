    public class DuckCopy
    {
        public static void CopyFields(object source, object target)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (target == null)
                throw new ArgumentNullException("target");
            FieldInfo[] fiSource = source.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            FieldInfo[] fiTarget = target.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (FieldInfo fiS in fiSource)
            {
                foreach (FieldInfo fiT in fiTarget)
                {
                    if (fiT.Name == fiS.Name)
                    {
                        fiT.SetValue(target, fiS.GetValue(source));
                        break;
                    }
                }
            }
        }
    }
