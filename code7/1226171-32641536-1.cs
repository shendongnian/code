    public static class SerializationInfoExtensions
    {
        public static IEnumerable<SerializationEntry> AsEnumerable(this SerializationInfo info)
        {
            if (info == null)
                throw new NullReferenceException();
            var enumerator = info.GetEnumerator();
            while (enumerator.MoveNext())
            {
                yield return enumerator.Current;
            }
        }
    }
