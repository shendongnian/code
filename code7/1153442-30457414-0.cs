    public class MyCouroutine
    {
        public static IEnumerator WaitForRealSeconds(float duration)
        {
            float start = Time.realtimeSinceStartup;
            while (Time.realtimeSinceStartup < start + duration)
            {
                yield return null;
            }
        }
    }
