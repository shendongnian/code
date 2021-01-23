    class Parent
    {
        public virtual void Foo()
        {
            StackTrace trace = new StackTrace();
            List<StackFrame> frames = new List<StackFrame>(trace.GetFrames());
            var thisMethod = frames[0].GetMethod().Name;
            //we don't want ourselves in the list
            frames.RemoveAt(0);
            foreach (var frame in frames)
            {
                var method = frame.GetMethod();
                //we only want foo's
                if (method.Name == thisMethod)
                {
                    Console.WriteLine(method.ReflectedType.FullName);
                }
                else
                {
                    // when we've run out, we can get out
                    break;
                }
            }
        }
    }
