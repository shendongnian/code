    struct MyStruct : IDisposable
    {
        private A m_A = new A();
        private B m_B = new B();
        public void Dispose()
        {
            m_A.Dispose();
            m_B.Dispose();
        }
    }
    class A : IDisposable
    {
        private bool m_IsDisposed;
        public void Dispose()
        {
            if (m_IsDisposed)
                throw new ObjectDisposedException();
            m_IsDisposed = true;
        }
    }
    class B : IDisposable
    {
        private bool m_IsDisposed;
        public void Dispose()
        {
            if (m_IsDisposed)
                throw new ObjectDisposedException();
            m_IsDisposed = true;
        }
    }
