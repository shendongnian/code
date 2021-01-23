    internal class IndentFrame
    {
        public string m_type, m_function;
        public bool m_bOutput = false;
        public int m_nExtra = 0;
        public IndentFrame(StackFrame frame)
        {
            m_type = frame.GetMethod().DeclaringType.Name;
            m_function = frame.GetMethod().ToString();
        }
        public bool Matches(StackFrame frame)
        {
            return (m_type == frame.GetMethod().DeclaringType.Name)
                && (m_function == frame.GetMethod().ToString());
        }
    }
    public class IndentDebug : IDisposable
    {
        internal static List<IndentFrame> m_frames = new List<IndentFrame>();
        public static void WriteLine(string text)
        {
            UpdateFrames();
            // Remember that this frame produced output.
            m_frames[m_frames.Count - 1].m_bOutput = true;
            // How much indent?
            int nIndent = 0;
            foreach (IndentFrame frame in m_frames)
                nIndent += (frame.m_bOutput ? 1 : 0) + frame.m_nExtra;
            String indent = new String(' ', (nIndent - 1) * 3);
            Debug.WriteLine(indent + text);
        }
        internal static void UpdateFrames()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame[] frames = stackTrace.GetFrames();
            // frames[] are ordered such that the current frame is at [0] but we
            // want the topmost frame in [0]
            Array.Reverse(frames);
            // Remove any obsolete frames from our list
            int i;
            for (i = 0; i < Math.Min(m_frames.Count, frames.Length); i++)
            {
                if (frames[i].GetMethod().DeclaringType == typeof(IndentDebug))
                    break;
                if (!m_frames[i].Matches(frames[i]))
                    break;
            }
            if (i < m_frames.Count)
                m_frames.RemoveRange(i, m_frames.Count - i);
            // Add any new frames
            while (m_frames.Count < frames.Length)
            {
                if (frames[m_frames.Count].GetMethod().DeclaringType == typeof(IndentDebug))
                    break;
                IndentFrame frame = new IndentFrame(frames[m_frames.Count]);
                m_frames.Add(frame);
            }
        }
        internal static void UpdateIndent(int add)
        {
            UpdateFrames();
            m_frames[m_frames.Count - 1].m_nExtra += add;
        }
        public IndentDebug(string text)
        {
            IndentDebug.UpdateIndent(1);
            IndentDebug.WriteLine(text);
        }
        public void Dispose()
        {
            IndentDebug.UpdateIndent(-1);
        }
    }
